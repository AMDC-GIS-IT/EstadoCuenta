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
   public class k2bretrieverowsperpage : GXProcedure
   {
      public k2bretrieverowsperpage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bretrieverowsperpage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_ProgramName ,
                           string aP1_GridName ,
                           out short aP2_RowsPerPage ,
                           out bool aP3_HasConfiguration )
      {
         this.AV10ProgramName = aP0_ProgramName;
         this.AV8GridName = aP1_GridName;
         this.AV11RowsPerPage = 0 ;
         this.AV9HasConfiguration = false ;
         initialize();
         ExecutePrivate();
         aP2_RowsPerPage=this.AV11RowsPerPage;
         aP3_HasConfiguration=this.AV9HasConfiguration;
      }

      public bool executeUdp( string aP0_ProgramName ,
                              string aP1_GridName ,
                              out short aP2_RowsPerPage )
      {
         execute(aP0_ProgramName, aP1_GridName, out aP2_RowsPerPage, out aP3_HasConfiguration);
         return AV9HasConfiguration ;
      }

      public void executeSubmit( string aP0_ProgramName ,
                                 string aP1_GridName ,
                                 out short aP2_RowsPerPage ,
                                 out bool aP3_HasConfiguration )
      {
         this.AV10ProgramName = aP0_ProgramName;
         this.AV8GridName = aP1_GridName;
         this.AV11RowsPerPage = 0 ;
         this.AV9HasConfiguration = false ;
         SubmitImpl();
         aP2_RowsPerPage=this.AV11RowsPerPage;
         aP3_HasConfiguration=this.AV9HasConfiguration;
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

      private short AV11RowsPerPage ;
      private string AV10ProgramName ;
      private string AV8GridName ;
      private bool AV9HasConfiguration ;
      private short aP2_RowsPerPage ;
      private bool aP3_HasConfiguration ;
   }

}
