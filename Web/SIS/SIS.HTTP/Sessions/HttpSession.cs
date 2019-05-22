﻿namespace SIS.HTTP.Sessions
{
    using SIS.HTTP.Common;
    using SIS.HTTP.Sessions.Contracts;
    using System.Collections.Generic;

    public class HttpSession : IHttpSession
    {
        private readonly Dictionary<string, object> parameters;

        public HttpSession(string id)
        {
            CoreValidator.ThrowIfNullOrEmpty(id, nameof(id));
            this.Id = id;
            this.parameters = new Dictionary<string, object>();
        }
        public string Id { get; }

        public void AddParameter(string name, object parameter)
        {
            CoreValidator.ThrowIfNullOrEmpty(name, nameof(name));
            CoreValidator.ThrowIfNull(parameter, nameof(parameter));
            if (this.ContainsParameter(name))
            {
                this.parameters[name] = parameter;
            }
            else
            {
                this.parameters.Add(name, parameter);
            }
        }

        public void ClearParameters()
        {
            this.parameters.Clear();
        }

        public bool ContainsParameter(string name)
        {
            CoreValidator.ThrowIfNullOrEmpty(name, nameof(name));
            return this.parameters.ContainsKey(name);
        }

        public object GetParameter(string name)
        {
            CoreValidator.ThrowIfNullOrEmpty(name, nameof(name));
            if (!this.ContainsParameter(name))
            {
                return null;
            }
            return this.parameters[name];
        }
    }
}
