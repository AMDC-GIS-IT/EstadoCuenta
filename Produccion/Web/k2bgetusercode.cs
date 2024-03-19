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
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class k2bgetusercode : GXProcedure
   {
      public k2bgetusercode( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bgetusercode( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out string aP0_UserCode )
      {
         this.AV9UserCode = "" ;
         initialize();
         ExecutePrivate();
         aP0_UserCode=this.AV9UserCode;
      }

      public string executeUdp( )
      {
         execute(out aP0_UserCode);
         return AV9UserCode ;
      }

      public void executeSubmit( out string aP0_UserCode )
      {
         this.AV9UserCode = "" ;
         SubmitImpl();
         aP0_UserCode=this.AV9UserCode;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_SdtK2BContext1 = AV8Context;
         new k2bgetcontext(context ).execute( out  GXt_SdtK2BContext1) ;
         AV8Context = GXt_SdtK2BContext1;
         AV9UserCode = AV8Context.gxTpr_Usercode;
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
         AV9UserCode = "";
         AV8Context = new SdtK2BContext(context);
         GXt_SdtK2BContext1 = new SdtK2BContext(context);
         /* GeneXus formulas. */
      }

      private string AV9UserCode ;
      private string aP0_UserCode ;
      private SdtK2BContext AV8Context ;
      private SdtK2BContext GXt_SdtK2BContext1 ;
   }

}
