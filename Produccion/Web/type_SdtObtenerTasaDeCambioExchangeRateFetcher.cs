using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Web.Services.Protocols;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [Serializable]
   public class SdtObtenerTasaDeCambioExchangeRateFetcher : GxUserType, IGxExternalObject
   {
      public SdtObtenerTasaDeCambioExchangeRateFetcher( )
      {
         /* Constructor for serialization */
      }

      public SdtObtenerTasaDeCambioExchangeRateFetcher( IGxContext context )
      {
         this.context = context;
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public GxSimpleCollection<string> obtenertasadecambio( string gxTp_apiKey ,
                                                             string gxTp_baseCurrency ,
                                                             string gxTp_targetCurrency ,
                                                             string gxTp_date )
      {
         GxSimpleCollection<string> returnobtenertasadecambio;
         returnobtenertasadecambio = new GxSimpleCollection<string>();
         System.Threading.Tasks.Task< System.String> externalParm0;
         externalParm0 = ExchangeRateFetcher.ObtenerTasaDeCambio(gxTp_apiKey, gxTp_baseCurrency, gxTp_targetCurrency, gxTp_date);
         returnobtenertasadecambio.ExternalInstance = (IList)CollectionUtils.ConvertToInternal( typeof(System.Threading.Tasks.Task< System.String>), externalParm0);
         return returnobtenertasadecambio ;
      }

      public Object ExternalInstance
      {
         get {
            return ObtenerTasaDeCambioExchangeRateFetcher_externalReference ;
         }

         set {
            ObtenerTasaDeCambioExchangeRateFetcher_externalReference = (ExchangeRateFetcher)(value);
         }

      }

      public void initialize( )
      {
         return  ;
      }

      protected ExchangeRateFetcher ObtenerTasaDeCambioExchangeRateFetcher_externalReference=null ;
   }

}
