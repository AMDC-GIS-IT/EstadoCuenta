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
   public class k2bisauthorizedactivitylist : GXProcedure
   {
      public k2bisauthorizedactivitylist( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bisauthorizedactivitylist( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> aP0_activityList )
      {
         this.AV9activityList = aP0_activityList;
         initialize();
         ExecutePrivate();
         aP0_activityList=this.AV9activityList;
      }

      public GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> executeUdp( )
      {
         execute(ref aP0_activityList);
         return AV9activityList ;
      }

      public void executeSubmit( ref GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> aP0_activityList )
      {
         this.AV9activityList = aP0_activityList;
         SubmitImpl();
         aP0_activityList=this.AV9activityList;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10GXV1 = 1;
         while ( AV10GXV1 <= AV9activityList.Count )
         {
            AV8activity = ((SdtK2BActivityList_K2BActivityListItem)AV9activityList.Item(AV10GXV1));
            AV8activity.gxTpr_Isauthorized = true;
            AV10GXV1 = (int)(AV10GXV1+1);
         }
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
         AV8activity = new SdtK2BActivityList_K2BActivityListItem(context);
         /* GeneXus formulas. */
      }

      private int AV10GXV1 ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> aP0_activityList ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV9activityList ;
      private SdtK2BActivityList_K2BActivityListItem AV8activity ;
   }

}
