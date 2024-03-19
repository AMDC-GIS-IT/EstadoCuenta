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
namespace GeneXus.Programs.k2btools.integrationprocedures {
   public class registerclient : GXProcedure
   {
      public registerclient( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public registerclient( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref string aP0_UserCode )
      {
         this.AV8UserCode = aP0_UserCode;
         initialize();
         ExecutePrivate();
         aP0_UserCode=this.AV8UserCode;
      }

      public string executeUdp( )
      {
         execute(ref aP0_UserCode);
         return AV8UserCode ;
      }

      public void executeSubmit( ref string aP0_UserCode )
      {
         this.AV8UserCode = aP0_UserCode;
         SubmitImpl();
         aP0_UserCode=this.AV8UserCode;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
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

      private string AV8UserCode ;
      private string aP0_UserCode ;
   }

}
