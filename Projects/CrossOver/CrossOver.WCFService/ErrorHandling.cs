using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Web;

namespace CrossOver.WCFService
{
     public class ErrorHandler : IErrorHandler 
    { 
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        { 
           
        }

        public bool HandleError(Exception error) 
        { 
            if (!EventLog.SourceExists("Operations")) EventLog.CreateEventSource("Operations", "Application"); 
            EventLog.WriteEntry("Operations", error.ToString()); 
            return false; 
        } 
    }

     public class ErrorServiceBehavior : IServiceBehavior
     {
         public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
         {

         }

         public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
         {

         }

         public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
         {
             ErrorHandler handler = new ErrorHandler();
             foreach (ChannelDispatcher dispatcher in serviceHostBase.ChannelDispatchers)
             {
                 dispatcher.ErrorHandlers.Add(handler);
             }
         }
     }

     public class ErrorHandlerBehavior : BehaviorExtensionElement
     {
         protected override object CreateBehavior()
         {
             return new ErrorServiceBehavior();
         }

         public override Type BehaviorType
         {
             get { return typeof(ErrorServiceBehavior); }
         }
     }
}