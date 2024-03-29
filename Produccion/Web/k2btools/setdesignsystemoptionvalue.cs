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
namespace GeneXus.Programs.k2btools {
   public class setdesignsystemoptionvalue : GXProcedure
   {
      public setdesignsystemoptionvalue( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public setdesignsystemoptionvalue( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_OptionName ,
                           string aP1_OptionValue )
      {
         this.AV8OptionName = aP0_OptionName;
         this.AV9OptionValue = aP1_OptionValue;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( string aP0_OptionName ,
                                 string aP1_OptionValue )
      {
         this.AV8OptionName = aP0_OptionName;
         this.AV9OptionValue = aP1_OptionValue;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10WebSession.Set(AV8OptionName, AV9OptionValue);
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
         AV10WebSession = context.GetSession();
         /* GeneXus formulas. */
      }

      private string AV8OptionName ;
      private string AV9OptionValue ;
      private IGxSession AV10WebSession ;
   }

}
