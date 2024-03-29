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
   public class k2bgetgridconfigurationsessionkey : GXProcedure
   {
      public k2bgetgridconfigurationsessionkey( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bgetgridconfigurationsessionkey( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_ProgramName ,
                           string aP1_GridName ,
                           out string aP2_SessionString )
      {
         this.AV9ProgramName = aP0_ProgramName;
         this.AV8GridName = aP1_GridName;
         this.AV10SessionString = "" ;
         initialize();
         ExecutePrivate();
         aP2_SessionString=this.AV10SessionString;
      }

      public string executeUdp( string aP0_ProgramName ,
                                string aP1_GridName )
      {
         execute(aP0_ProgramName, aP1_GridName, out aP2_SessionString);
         return AV10SessionString ;
      }

      public void executeSubmit( string aP0_ProgramName ,
                                 string aP1_GridName ,
                                 out string aP2_SessionString )
      {
         this.AV9ProgramName = aP0_ProgramName;
         this.AV8GridName = aP1_GridName;
         this.AV10SessionString = "" ;
         SubmitImpl();
         aP2_SessionString=this.AV10SessionString;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10SessionString = StringUtil.Trim( AV9ProgramName) + "#" + StringUtil.Trim( AV8GridName) + "GridConfiguration";
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
         AV10SessionString = "";
         /* GeneXus formulas. */
      }

      private string AV9ProgramName ;
      private string AV8GridName ;
      private string AV10SessionString ;
      private string aP2_SessionString ;
   }

}
