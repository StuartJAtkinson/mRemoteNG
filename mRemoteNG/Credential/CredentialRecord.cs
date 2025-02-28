﻿using System;
using System.ComponentModel;
using System.Security;


namespace mRemoteNG.Credential
{
    public class CredentialRecord : ICredentialRecord
    {
        private string _title = "New Credential";
        private string _username = "";
        private SecureString _password = new();
        private string _domain = "";

        public Guid Id { get; } = Guid.NewGuid();

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                RaisePropertyChangedEvent(nameof(Title));
            }
        }

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                RaisePropertyChangedEvent(nameof(Username));
            }
        }

        public SecureString Password
        {
            get => _password;
            set
            {
                _password = value;
                RaisePropertyChangedEvent(nameof(Password));
            }
        }

        public string Domain
        {
            get => _domain;
            set
            {
                _domain = value;
                RaisePropertyChangedEvent(nameof(Domain));
            }
        }


        public CredentialRecord()
        {
        }

        public CredentialRecord(ICredentialRecord otherCredential)
        {
            Username = otherCredential.Username;
            Password = otherCredential.Password;
            Domain = otherCredential.Domain;
        }

        public CredentialRecord(Guid customGuid)
        {
            Id = customGuid;
        }

        public override string ToString()
        {
            return Title;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChangedEvent(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}