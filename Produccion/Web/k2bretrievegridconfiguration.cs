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
   public class k2bretrievegridconfiguration : GXProcedure
   {
      public k2bretrievegridconfiguration( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bretrievegridconfiguration( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_ProgramName ,
                           string aP1_GridName ,
                           out SdtK2BGridConfiguration aP2_GridConfiguration )
      {
         this.AV9ProgramName = aP0_ProgramName;
         this.AV8GridName = aP1_GridName;
         this.AV10GridConfiguration = new SdtK2BGridConfiguration(context) ;
         initialize();
         ExecutePrivate();
         aP2_GridConfiguration=this.AV10GridConfiguration;
      }

      public SdtK2BGridConfiguration executeUdp( string aP0_ProgramName ,
                                                 string aP1_GridName )
      {
         execute(aP0_ProgramName, aP1_GridName, out aP2_GridConfiguration);
         return AV10GridConfiguration ;
      }

      public void executeSubmit( string aP0_ProgramName ,
                                 string aP1_GridName ,
                                 out SdtK2BGridConfiguration aP2_GridConfiguration )
      {
         this.AV9ProgramName = aP0_ProgramName;
         this.AV8GridName = aP1_GridName;
         this.AV10GridConfiguration = new SdtK2BGridConfiguration(context) ;
         SubmitImpl();
         aP2_GridConfiguration=this.AV10GridConfiguration;
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
         AV10GridConfiguration = new SdtK2BGridConfiguration(context);
         /* GeneXus formulas. */
      }

      private string AV9ProgramName ;
      private string AV8GridName ;
      private SdtK2BGridConfiguration aP2_GridConfiguration ;
      private SdtK2BGridConfiguration AV10GridConfiguration ;
   }

}
