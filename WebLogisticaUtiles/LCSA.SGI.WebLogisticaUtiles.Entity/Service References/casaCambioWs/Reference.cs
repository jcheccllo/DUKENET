﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://casacambio.upc.edu/", ConfigurationName="casaCambioWs.CasaCambioWs")]
    public interface CasaCambioWs {
        
        // CODEGEN: Generating message contract since element name name from namespace  is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://casacambio.upc.edu/CasaCambioWs/helloRequest", ReplyAction="http://casacambio.upc.edu/CasaCambioWs/helloResponse")]
        LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs.helloResponse hello(LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs.helloRequest request);
        
        // CODEGEN: Generating message contract since message part namespace () does not match the default value (http://casacambio.upc.edu/)
        [System.ServiceModel.OperationContractAttribute(Action="http://casacambio.upc.edu/CasaCambioWs/cambiarDolaresaSolesRequest", ReplyAction="http://casacambio.upc.edu/CasaCambioWs/cambiarDolaresaSolesResponse")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs.cambiarDolaresaSolesResponse cambiarDolaresaSoles(LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs.cambiarDolaresaSolesRequest request);
        
        // CODEGEN: Generating message contract since message part namespace () does not match the default value (http://casacambio.upc.edu/)
        [System.ServiceModel.OperationContractAttribute(Action="http://casacambio.upc.edu/CasaCambioWs/cambiarSolesaDolaresRequest", ReplyAction="http://casacambio.upc.edu/CasaCambioWs/cambiarSolesaDolaresResponse")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs.cambiarSolesaDolaresResponse cambiarSolesaDolares(LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs.cambiarSolesaDolaresRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class helloRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="hello", Namespace="http://casacambio.upc.edu/", Order=0)]
        public LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs.helloRequestBody Body;
        
        public helloRequest() {
        }
        
        public helloRequest(LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs.helloRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class helloRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string name;
        
        public helloRequestBody() {
        }
        
        public helloRequestBody(string name) {
            this.name = name;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class helloResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="helloResponse", Namespace="http://casacambio.upc.edu/", Order=0)]
        public LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs.helloResponseBody Body;
        
        public helloResponse() {
        }
        
        public helloResponse(LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs.helloResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class helloResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string @return;
        
        public helloResponseBody() {
        }
        
        public helloResponseBody(string @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="cambiarDolaresaSoles", WrapperNamespace="http://casacambio.upc.edu/", IsWrapped=true)]
    public partial class cambiarDolaresaSolesRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public double monto;
        
        public cambiarDolaresaSolesRequest() {
        }
        
        public cambiarDolaresaSolesRequest(double monto) {
            this.monto = monto;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="cambiarDolaresaSolesResponse", WrapperNamespace="http://casacambio.upc.edu/", IsWrapped=true)]
    public partial class cambiarDolaresaSolesResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public double @return;
        
        public cambiarDolaresaSolesResponse() {
        }
        
        public cambiarDolaresaSolesResponse(double @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="cambiarSolesaDolares", WrapperNamespace="http://casacambio.upc.edu/", IsWrapped=true)]
    public partial class cambiarSolesaDolaresRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public double monto;
        
        public cambiarSolesaDolaresRequest() {
        }
        
        public cambiarSolesaDolaresRequest(double monto) {
            this.monto = monto;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="cambiarSolesaDolaresResponse", WrapperNamespace="http://casacambio.upc.edu/", IsWrapped=true)]
    public partial class cambiarSolesaDolaresResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public double @return;
        
        public cambiarSolesaDolaresResponse() {
        }
        
        public cambiarSolesaDolaresResponse(double @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface CasaCambioWsChannel : LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs.CasaCambioWs, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CasaCambioWsClient : System.ServiceModel.ClientBase<LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs.CasaCambioWs>, LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs.CasaCambioWs {
        
        public CasaCambioWsClient() {
        }
        
        public CasaCambioWsClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CasaCambioWsClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CasaCambioWsClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CasaCambioWsClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs.helloResponse LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs.CasaCambioWs.hello(LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs.helloRequest request) {
            return base.Channel.hello(request);
        }
        
        public string hello(string name) {
            LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs.helloRequest inValue = new LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs.helloRequest();
            inValue.Body = new LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs.helloRequestBody();
            inValue.Body.name = name;
            LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs.helloResponse retVal = ((LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs.CasaCambioWs)(this)).hello(inValue);
            return retVal.Body.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs.cambiarDolaresaSolesResponse LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs.CasaCambioWs.cambiarDolaresaSoles(LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs.cambiarDolaresaSolesRequest request) {
            return base.Channel.cambiarDolaresaSoles(request);
        }
        
        public double cambiarDolaresaSoles(double monto) {
            LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs.cambiarDolaresaSolesRequest inValue = new LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs.cambiarDolaresaSolesRequest();
            inValue.monto = monto;
            LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs.cambiarDolaresaSolesResponse retVal = ((LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs.CasaCambioWs)(this)).cambiarDolaresaSoles(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs.cambiarSolesaDolaresResponse LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs.CasaCambioWs.cambiarSolesaDolares(LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs.cambiarSolesaDolaresRequest request) {
            return base.Channel.cambiarSolesaDolares(request);
        }
        
        public double cambiarSolesaDolares(double monto) {
            LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs.cambiarSolesaDolaresRequest inValue = new LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs.cambiarSolesaDolaresRequest();
            inValue.monto = monto;
            LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs.cambiarSolesaDolaresResponse retVal = ((LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs.CasaCambioWs)(this)).cambiarSolesaDolares(inValue);
            return retVal.@return;
        }
    }
}
