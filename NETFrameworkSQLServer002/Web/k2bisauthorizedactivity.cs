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
   public class k2bisauthorizedactivity : GXProcedure
   {
      public k2bisauthorizedactivity( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bisauthorizedactivity( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( SdtK2BActivity aP0_activity ,
                           out bool aP1_IsAuthorized )
      {
         this.AV8activity = aP0_activity;
         this.AV9IsAuthorized = false ;
         initialize();
         ExecutePrivate();
         aP1_IsAuthorized=this.AV9IsAuthorized;
      }

      public bool executeUdp( SdtK2BActivity aP0_activity )
      {
         execute(aP0_activity, out aP1_IsAuthorized);
         return AV9IsAuthorized ;
      }

      public void executeSubmit( SdtK2BActivity aP0_activity ,
                                 out bool aP1_IsAuthorized )
      {
         this.AV8activity = aP0_activity;
         this.AV9IsAuthorized = false ;
         SubmitImpl();
         aP1_IsAuthorized=this.AV9IsAuthorized;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV11ActivityListItem.gxTpr_Activity = AV8activity;
         AV10ActivityList.Add(AV11ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV10ActivityList) ;
         AV9IsAuthorized = ((SdtK2BActivityList_K2BActivityListItem)AV10ActivityList.Item(1)).gxTpr_Isauthorized;
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
         AV11ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV10ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "EstadoCuenta");
         /* GeneXus formulas. */
      }

      private bool AV9IsAuthorized ;
      private bool aP1_IsAuthorized ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV10ActivityList ;
      private SdtK2BActivity AV8activity ;
      private SdtK2BActivityList_K2BActivityListItem AV11ActivityListItem ;
   }

}