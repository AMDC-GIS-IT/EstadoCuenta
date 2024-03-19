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
   public class k2bisauthenticated : GXProcedure
   {
      public k2bisauthenticated( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bisauthenticated( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out bool aP0_IsAuthenticated )
      {
         this.AV8IsAuthenticated = false ;
         initialize();
         ExecutePrivate();
         aP0_IsAuthenticated=this.AV8IsAuthenticated;
      }

      public bool executeUdp( )
      {
         execute(out aP0_IsAuthenticated);
         return AV8IsAuthenticated ;
      }

      public void executeSubmit( out bool aP0_IsAuthenticated )
      {
         this.AV8IsAuthenticated = false ;
         SubmitImpl();
         aP0_IsAuthenticated=this.AV8IsAuthenticated;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8IsAuthenticated = true;
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
         /* GeneXus formulas. */
      }

      private bool AV8IsAuthenticated ;
      private bool aP0_IsAuthenticated ;
   }

}
