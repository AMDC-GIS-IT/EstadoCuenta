using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class k2btoolsgetuseencryption : GXProcedure
   {
      public k2btoolsgetuseencryption( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2btoolsgetuseencryption( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out string aP0_encrypt )
      {
         this.AV9encrypt = "" ;
         initialize();
         ExecutePrivate();
         aP0_encrypt=this.AV9encrypt;
      }

      public string executeUdp( )
      {
         execute(out aP0_encrypt);
         return AV9encrypt ;
      }

      public void executeSubmit( out string aP0_encrypt )
      {
         this.AV9encrypt = "" ;
         SubmitImpl();
         aP0_encrypt=this.AV9encrypt;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9encrypt = AV8ConfigurationManager.getvalue("USE_ENCRYPTION");
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV9encrypt = "";
         AV8ConfigurationManager = new GeneXus.Core.genexus.common.configuration.SdtConfigurationManager(context);
         /* GeneXus formulas. */
      }

      private string AV9encrypt ;
      private GeneXus.Core.genexus.common.configuration.SdtConfigurationManager AV8ConfigurationManager ;
      private string aP0_encrypt ;
   }

   [ServiceContract(Namespace = "GeneXus.Programs.k2btoolsgetuseencryption_services")]
   [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   public class k2btoolsgetuseencryption_services : GxRestService
   {
      [OperationContract(Name = "K2BToolsGetUseEncryption" )]
      [WebInvoke(Method =  "POST" ,
      	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
      	ResponseFormat = WebMessageFormat.Json,
      	UriTemplate = "/")]
      public void execute( out string encrypt )
      {
         encrypt = "" ;
         try
         {
            if ( ! ProcessHeaders("k2btoolsgetuseencryption") )
            {
               return  ;
            }
            k2btoolsgetuseencryption worker = new k2btoolsgetuseencryption(context);
            worker.IsMain = RunAsMain ;
            worker.execute(out encrypt );
            worker.cleanup( );
         }
         catch ( Exception e )
         {
            WebException(e);
         }
         finally
         {
            Cleanup();
         }
      }

   }

}
