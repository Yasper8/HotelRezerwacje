﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RezerwacjeClient.CustomerServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Customers", Namespace="http://schemas.datacontract.org/2004/07/RezerwacjeService")]
    [System.SerializableAttribute()]
    public partial class Customers : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SurnameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TelephoneField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Surname {
            get {
                return this.SurnameField;
            }
            set {
                if ((object.ReferenceEquals(this.SurnameField, value) != true)) {
                    this.SurnameField = value;
                    this.RaisePropertyChanged("Surname");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Telephone {
            get {
                return this.TelephoneField;
            }
            set {
                if ((object.ReferenceEquals(this.TelephoneField, value) != true)) {
                    this.TelephoneField = value;
                    this.RaisePropertyChanged("Telephone");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CustomerServiceReference.ICustomerService")]
    public interface ICustomerService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/FindAll", ReplyAction="http://tempuri.org/ICustomerService/FindAllResponse")]
        RezerwacjeClient.CustomerServiceReference.Customers[] FindAll(string sessionId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/FindAll", ReplyAction="http://tempuri.org/ICustomerService/FindAllResponse")]
        System.Threading.Tasks.Task<RezerwacjeClient.CustomerServiceReference.Customers[]> FindAllAsync(string sessionId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/FindById", ReplyAction="http://tempuri.org/ICustomerService/FindByIdResponse")]
        RezerwacjeClient.CustomerServiceReference.Customers FindById(string sessionId, int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/FindById", ReplyAction="http://tempuri.org/ICustomerService/FindByIdResponse")]
        System.Threading.Tasks.Task<RezerwacjeClient.CustomerServiceReference.Customers> FindByIdAsync(string sessionId, int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/Save", ReplyAction="http://tempuri.org/ICustomerService/SaveResponse")]
        int Save(string sessionId, RezerwacjeClient.CustomerServiceReference.Customers customer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/Save", ReplyAction="http://tempuri.org/ICustomerService/SaveResponse")]
        System.Threading.Tasks.Task<int> SaveAsync(string sessionId, RezerwacjeClient.CustomerServiceReference.Customers customer);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICustomerServiceChannel : RezerwacjeClient.CustomerServiceReference.ICustomerService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CustomerServiceClient : System.ServiceModel.ClientBase<RezerwacjeClient.CustomerServiceReference.ICustomerService>, RezerwacjeClient.CustomerServiceReference.ICustomerService {
        
        public CustomerServiceClient() {
        }
        
        public CustomerServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CustomerServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CustomerServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CustomerServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public RezerwacjeClient.CustomerServiceReference.Customers[] FindAll(string sessionId) {
            return base.Channel.FindAll(sessionId);
        }
        
        public System.Threading.Tasks.Task<RezerwacjeClient.CustomerServiceReference.Customers[]> FindAllAsync(string sessionId) {
            return base.Channel.FindAllAsync(sessionId);
        }
        
        public RezerwacjeClient.CustomerServiceReference.Customers FindById(string sessionId, int id) {
            return base.Channel.FindById(sessionId, id);
        }
        
        public System.Threading.Tasks.Task<RezerwacjeClient.CustomerServiceReference.Customers> FindByIdAsync(string sessionId, int id) {
            return base.Channel.FindByIdAsync(sessionId, id);
        }
        
        public int Save(string sessionId, RezerwacjeClient.CustomerServiceReference.Customers customer) {
            return base.Channel.Save(sessionId, customer);
        }
        
        public System.Threading.Tasks.Task<int> SaveAsync(string sessionId, RezerwacjeClient.CustomerServiceReference.Customers customer) {
            return base.Channel.SaveAsync(sessionId, customer);
        }
    }
}
