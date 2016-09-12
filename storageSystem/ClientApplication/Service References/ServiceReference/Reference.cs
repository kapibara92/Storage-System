﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientApplication.ServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProductList", Namespace="http://storageService.org")]
    [System.SerializableAttribute()]
    public partial class ProductList : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int idField;
        
        private long codeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nameField;
        
        private System.Nullable<System.DateTime> guaranteeDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TypeField;
        
        private System.Nullable<int> quantityField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=1)]
        public long code {
            get {
                return this.codeField;
            }
            set {
                if ((this.codeField.Equals(value) != true)) {
                    this.codeField = value;
                    this.RaisePropertyChanged("code");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=3)]
        public System.Nullable<System.DateTime> guaranteeDate {
            get {
                return this.guaranteeDateField;
            }
            set {
                if ((this.guaranteeDateField.Equals(value) != true)) {
                    this.guaranteeDateField = value;
                    this.RaisePropertyChanged("guaranteeDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string Type {
            get {
                return this.TypeField;
            }
            set {
                if ((object.ReferenceEquals(this.TypeField, value) != true)) {
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=5)]
        public System.Nullable<int> quantity {
            get {
                return this.quantityField;
            }
            set {
                if ((this.quantityField.Equals(value) != true)) {
                    this.quantityField = value;
                    this.RaisePropertyChanged("quantity");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ArrayOfString", Namespace="http://storageService.org", ItemName="string")]
    [System.SerializableAttribute()]
    public class ArrayOfString : System.Collections.Generic.List<string> {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://storageService.org", ConfigurationName="ServiceReference.StorageServiceSoap")]
    public interface StorageServiceSoap {
        
        // CODEGEN: Generating message contract since element name nameProduct from namespace http://storageService.org is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://storageService.org/AddOrder", ReplyAction="*")]
        ClientApplication.ServiceReference.AddOrderResponse AddOrder(ClientApplication.ServiceReference.AddOrderRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://storageService.org/AddOrder", ReplyAction="*")]
        System.Threading.Tasks.Task<ClientApplication.ServiceReference.AddOrderResponse> AddOrderAsync(ClientApplication.ServiceReference.AddOrderRequest request);
        
        // CODEGEN: Generating message contract since element name showProductsResult from namespace http://storageService.org is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://storageService.org/showProducts", ReplyAction="*")]
        ClientApplication.ServiceReference.showProductsResponse showProducts(ClientApplication.ServiceReference.showProductsRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://storageService.org/showProducts", ReplyAction="*")]
        System.Threading.Tasks.Task<ClientApplication.ServiceReference.showProductsResponse> showProductsAsync(ClientApplication.ServiceReference.showProductsRequest request);
        
        // CODEGEN: Generating message contract since element name getDeliveryTypeResult from namespace http://storageService.org is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://storageService.org/getDeliveryType", ReplyAction="*")]
        ClientApplication.ServiceReference.getDeliveryTypeResponse getDeliveryType(ClientApplication.ServiceReference.getDeliveryTypeRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://storageService.org/getDeliveryType", ReplyAction="*")]
        System.Threading.Tasks.Task<ClientApplication.ServiceReference.getDeliveryTypeResponse> getDeliveryTypeAsync(ClientApplication.ServiceReference.getDeliveryTypeRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddOrderRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AddOrder", Namespace="http://storageService.org", Order=0)]
        public ClientApplication.ServiceReference.AddOrderRequestBody Body;
        
        public AddOrderRequest() {
        }
        
        public AddOrderRequest(ClientApplication.ServiceReference.AddOrderRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://storageService.org")]
    public partial class AddOrderRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string nameProduct;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string delivery;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string address;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public int quantity;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public long code;
        
        public AddOrderRequestBody() {
        }
        
        public AddOrderRequestBody(string nameProduct, string delivery, string address, int quantity, long code) {
            this.nameProduct = nameProduct;
            this.delivery = delivery;
            this.address = address;
            this.quantity = quantity;
            this.code = code;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddOrderResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AddOrderResponse", Namespace="http://storageService.org", Order=0)]
        public ClientApplication.ServiceReference.AddOrderResponseBody Body;
        
        public AddOrderResponse() {
        }
        
        public AddOrderResponse(ClientApplication.ServiceReference.AddOrderResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class AddOrderResponseBody {
        
        public AddOrderResponseBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class showProductsRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="showProducts", Namespace="http://storageService.org", Order=0)]
        public ClientApplication.ServiceReference.showProductsRequestBody Body;
        
        public showProductsRequest() {
        }
        
        public showProductsRequest(ClientApplication.ServiceReference.showProductsRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class showProductsRequestBody {
        
        public showProductsRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class showProductsResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="showProductsResponse", Namespace="http://storageService.org", Order=0)]
        public ClientApplication.ServiceReference.showProductsResponseBody Body;
        
        public showProductsResponse() {
        }
        
        public showProductsResponse(ClientApplication.ServiceReference.showProductsResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://storageService.org")]
    public partial class showProductsResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public ClientApplication.ServiceReference.ProductList[] showProductsResult;
        
        public showProductsResponseBody() {
        }
        
        public showProductsResponseBody(ClientApplication.ServiceReference.ProductList[] showProductsResult) {
            this.showProductsResult = showProductsResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getDeliveryTypeRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="getDeliveryType", Namespace="http://storageService.org", Order=0)]
        public ClientApplication.ServiceReference.getDeliveryTypeRequestBody Body;
        
        public getDeliveryTypeRequest() {
        }
        
        public getDeliveryTypeRequest(ClientApplication.ServiceReference.getDeliveryTypeRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class getDeliveryTypeRequestBody {
        
        public getDeliveryTypeRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getDeliveryTypeResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="getDeliveryTypeResponse", Namespace="http://storageService.org", Order=0)]
        public ClientApplication.ServiceReference.getDeliveryTypeResponseBody Body;
        
        public getDeliveryTypeResponse() {
        }
        
        public getDeliveryTypeResponse(ClientApplication.ServiceReference.getDeliveryTypeResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://storageService.org")]
    public partial class getDeliveryTypeResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public ClientApplication.ServiceReference.ArrayOfString getDeliveryTypeResult;
        
        public getDeliveryTypeResponseBody() {
        }
        
        public getDeliveryTypeResponseBody(ClientApplication.ServiceReference.ArrayOfString getDeliveryTypeResult) {
            this.getDeliveryTypeResult = getDeliveryTypeResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface StorageServiceSoapChannel : ClientApplication.ServiceReference.StorageServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class StorageServiceSoapClient : System.ServiceModel.ClientBase<ClientApplication.ServiceReference.StorageServiceSoap>, ClientApplication.ServiceReference.StorageServiceSoap {
        
        public StorageServiceSoapClient() {
        }
        
        public StorageServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public StorageServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StorageServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StorageServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ClientApplication.ServiceReference.AddOrderResponse ClientApplication.ServiceReference.StorageServiceSoap.AddOrder(ClientApplication.ServiceReference.AddOrderRequest request) {
            return base.Channel.AddOrder(request);
        }
        
        public void AddOrder(string nameProduct, string delivery, string address, int quantity, long code) {
            ClientApplication.ServiceReference.AddOrderRequest inValue = new ClientApplication.ServiceReference.AddOrderRequest();
            inValue.Body = new ClientApplication.ServiceReference.AddOrderRequestBody();
            inValue.Body.nameProduct = nameProduct;
            inValue.Body.delivery = delivery;
            inValue.Body.address = address;
            inValue.Body.quantity = quantity;
            inValue.Body.code = code;
            ClientApplication.ServiceReference.AddOrderResponse retVal = ((ClientApplication.ServiceReference.StorageServiceSoap)(this)).AddOrder(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ClientApplication.ServiceReference.AddOrderResponse> ClientApplication.ServiceReference.StorageServiceSoap.AddOrderAsync(ClientApplication.ServiceReference.AddOrderRequest request) {
            return base.Channel.AddOrderAsync(request);
        }
        
        public System.Threading.Tasks.Task<ClientApplication.ServiceReference.AddOrderResponse> AddOrderAsync(string nameProduct, string delivery, string address, int quantity, long code) {
            ClientApplication.ServiceReference.AddOrderRequest inValue = new ClientApplication.ServiceReference.AddOrderRequest();
            inValue.Body = new ClientApplication.ServiceReference.AddOrderRequestBody();
            inValue.Body.nameProduct = nameProduct;
            inValue.Body.delivery = delivery;
            inValue.Body.address = address;
            inValue.Body.quantity = quantity;
            inValue.Body.code = code;
            return ((ClientApplication.ServiceReference.StorageServiceSoap)(this)).AddOrderAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ClientApplication.ServiceReference.showProductsResponse ClientApplication.ServiceReference.StorageServiceSoap.showProducts(ClientApplication.ServiceReference.showProductsRequest request) {
            return base.Channel.showProducts(request);
        }
        
        public ClientApplication.ServiceReference.ProductList[] showProducts() {
            ClientApplication.ServiceReference.showProductsRequest inValue = new ClientApplication.ServiceReference.showProductsRequest();
            inValue.Body = new ClientApplication.ServiceReference.showProductsRequestBody();
            ClientApplication.ServiceReference.showProductsResponse retVal = ((ClientApplication.ServiceReference.StorageServiceSoap)(this)).showProducts(inValue);
            return retVal.Body.showProductsResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ClientApplication.ServiceReference.showProductsResponse> ClientApplication.ServiceReference.StorageServiceSoap.showProductsAsync(ClientApplication.ServiceReference.showProductsRequest request) {
            return base.Channel.showProductsAsync(request);
        }
        
        public System.Threading.Tasks.Task<ClientApplication.ServiceReference.showProductsResponse> showProductsAsync() {
            ClientApplication.ServiceReference.showProductsRequest inValue = new ClientApplication.ServiceReference.showProductsRequest();
            inValue.Body = new ClientApplication.ServiceReference.showProductsRequestBody();
            return ((ClientApplication.ServiceReference.StorageServiceSoap)(this)).showProductsAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ClientApplication.ServiceReference.getDeliveryTypeResponse ClientApplication.ServiceReference.StorageServiceSoap.getDeliveryType(ClientApplication.ServiceReference.getDeliveryTypeRequest request) {
            return base.Channel.getDeliveryType(request);
        }
        
        public ClientApplication.ServiceReference.ArrayOfString getDeliveryType() {
            ClientApplication.ServiceReference.getDeliveryTypeRequest inValue = new ClientApplication.ServiceReference.getDeliveryTypeRequest();
            inValue.Body = new ClientApplication.ServiceReference.getDeliveryTypeRequestBody();
            ClientApplication.ServiceReference.getDeliveryTypeResponse retVal = ((ClientApplication.ServiceReference.StorageServiceSoap)(this)).getDeliveryType(inValue);
            return retVal.Body.getDeliveryTypeResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ClientApplication.ServiceReference.getDeliveryTypeResponse> ClientApplication.ServiceReference.StorageServiceSoap.getDeliveryTypeAsync(ClientApplication.ServiceReference.getDeliveryTypeRequest request) {
            return base.Channel.getDeliveryTypeAsync(request);
        }
        
        public System.Threading.Tasks.Task<ClientApplication.ServiceReference.getDeliveryTypeResponse> getDeliveryTypeAsync() {
            ClientApplication.ServiceReference.getDeliveryTypeRequest inValue = new ClientApplication.ServiceReference.getDeliveryTypeRequest();
            inValue.Body = new ClientApplication.ServiceReference.getDeliveryTypeRequestBody();
            return ((ClientApplication.ServiceReference.StorageServiceSoap)(this)).getDeliveryTypeAsync(inValue);
        }
    }
}
