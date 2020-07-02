using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FluentEnsure
{
    public delegate ExceptionConfiguration<T> Configure<T>(ExceptionConfiguration<T> configuration);

    public class ExceptionConfiguration<T>
    {
        private readonly List<Func<T, string, string>> _messages = new List<Func<T, string, string>>();

        private readonly IDictionary<string, object> _data = new Dictionary<string, object>();

        public ExceptionConfiguration<T> Message(Func<T, string, string> message)
        {
            _messages.Add(message);

            return this;
        }

        public ExceptionConfiguration<T> Data(IDictionary<string, object?> data)
        {
            foreach (var (key, value) in data)
            {
                _data.Add(key, value ?? "null");
            }

            return this;
        }

        private string BuildMessage(T value, string name) =>
            string.Join(
                "\r\n\r\n",
                _messages.Select(message => message(value, name)));
            

        public Exception Raise(Candidate<T> ensure)
        {
            var message = BuildMessage(ensure.Value, ensure.Name);

            var exception = new GuardClauseNotMetException(
                message, 
                (ensure.Value, ensure.Name));

            foreach (var (key, value) in _data)
            {
                exception.Data.Add(key, value);
            }

            return exception;
        }
    }

    public static class ExceptionConfiguration
    {
        public static Configure<T> Default<T>(
            this Configure<T>? configuration,
            string message,
            params (string, object?)[] data)
        {
            ExceptionConfiguration<T> DefaultConfig(ExceptionConfiguration<T> _) => _
                .Message(message)
                .Data(data.ToDictionary(d => d.Item1, d => d.Item2));

            if (configuration is null) return DefaultConfig;
            return configuration + DefaultConfig;
        }

        public static ExceptionConfiguration<T> Message<T>(
            this ExceptionConfiguration<T> configuration,
            string message) => configuration.Message((_, __) => message);

        public static ExceptionConfiguration<T> Data<T>(
            this ExceptionConfiguration<T> configuration,
            object? data) =>
            data is null
                ? configuration
                : configuration.Data(
                    data.GetType()
                        .GetProperties()
                        .ToDictionary(
                            p => p.Name,
                            p => p.TryGetValue(data)));

        private static object? TryGetValue(
            this PropertyInfo member,
            object? parent) => member.GetValue(parent);
    }
}