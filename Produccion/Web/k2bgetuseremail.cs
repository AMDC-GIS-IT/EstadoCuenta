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
   public class k2bgetuseremail : GXProcedure
   {
      public k2bgetuseremail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bgetuseremail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out string aP0_UserEmail )
      {
         this.AV8UserEmail = "" ;
         initialize();
         ExecutePrivate();
         aP0_UserEmail=this.AV8UserEmail;
      }

      public string executeUdp( )
      {
         execute(out aP0_UserEmail);
         return AV8UserEmail ;
      }

      public void executeSubmit( out string aP0_UserEmail )
      {
         this.AV8UserEmail = "" ;
         SubmitImpl();
         aP0_UserEmail=this.AV8UserEmail;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8UserEmail = "sample@example.com";
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
         AV8UserEmail = "";
         /* GeneXus formulas. */
      }

      private string AV8UserEmail ;
      private string aP0_UserEmail ;
   }

}
