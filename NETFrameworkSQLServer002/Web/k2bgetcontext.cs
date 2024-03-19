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
   public class k2bgetcontext : GXProcedure
   {
      public k2bgetcontext( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bgetcontext( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out SdtK2BContext aP0_Context )
      {
         this.AV8Context = new SdtK2BContext(context) ;
         initialize();
         ExecutePrivate();
         aP0_Context=this.AV8Context;
      }

      public SdtK2BContext executeUdp( )
      {
         execute(out aP0_Context);
         return AV8Context ;
      }

      public void executeSubmit( out SdtK2BContext aP0_Context )
      {
         this.AV8Context = new SdtK2BContext(context) ;
         SubmitImpl();
         aP0_Context=this.AV8Context;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_char1 = AV9Data;
         new k2bsessionget(context ).execute(  "Context", out  GXt_char1) ;
         AV9Data = GXt_char1;
         AV8Context.FromXml(AV9Data, null, "", "");
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
         AV8Context = new SdtK2BContext(context);
         AV9Data = "";
         GXt_char1 = "";
         /* GeneXus formulas. */
      }

      private string GXt_char1 ;
      private string AV9Data ;
      private SdtK2BContext aP0_Context ;
      private SdtK2BContext AV8Context ;
   }

}
