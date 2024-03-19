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
   public class k2bgetsearchableentities : GXProcedure
   {
      public k2bgetsearchableentities( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bgetsearchableentities( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<SdtSearchableTransactions_SearchableTransactionsItem> aP0_SearchableTransactions )
      {
         this.AV11SearchableTransactions = new GXBaseCollection<SdtSearchableTransactions_SearchableTransactionsItem>( context, "SearchableTransactionsItem", "EstadoCuenta") ;
         initialize();
         ExecutePrivate();
         aP0_SearchableTransactions=this.AV11SearchableTransactions;
      }

      public GXBaseCollection<SdtSearchableTransactions_SearchableTransactionsItem> executeUdp( )
      {
         execute(out aP0_SearchableTransactions);
         return AV11SearchableTransactions ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSearchableTransactions_SearchableTransactionsItem> aP0_SearchableTransactions )
      {
         this.AV11SearchableTransactions = new GXBaseCollection<SdtSearchableTransactions_SearchableTransactionsItem>( context, "SearchableTransactionsItem", "EstadoCuenta") ;
         SubmitImpl();
         aP0_SearchableTransactions=this.AV11SearchableTransactions;
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
         AV11SearchableTransactions = new GXBaseCollection<SdtSearchableTransactions_SearchableTransactionsItem>( context, "SearchableTransactionsItem", "EstadoCuenta");
         /* GeneXus formulas. */
      }

      private GXBaseCollection<SdtSearchableTransactions_SearchableTransactionsItem> aP0_SearchableTransactions ;
      private GXBaseCollection<SdtSearchableTransactions_SearchableTransactionsItem> AV11SearchableTransactions ;
   }

}
