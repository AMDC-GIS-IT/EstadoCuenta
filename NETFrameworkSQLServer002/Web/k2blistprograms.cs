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
   public class k2blistprograms : GXProcedure
   {
      public k2blistprograms( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2blistprograms( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<SdtK2BProgramNames_ProgramName> aP0_ProgramNames )
      {
         this.AV8ProgramNames = new GXBaseCollection<SdtK2BProgramNames_ProgramName>( context, "ProgramName", "EstadoCuenta") ;
         initialize();
         ExecutePrivate();
         aP0_ProgramNames=this.AV8ProgramNames;
      }

      public GXBaseCollection<SdtK2BProgramNames_ProgramName> executeUdp( )
      {
         execute(out aP0_ProgramNames);
         return AV8ProgramNames ;
      }

      public void executeSubmit( out GXBaseCollection<SdtK2BProgramNames_ProgramName> aP0_ProgramNames )
      {
         this.AV8ProgramNames = new GXBaseCollection<SdtK2BProgramNames_ProgramName>( context, "ProgramName", "EstadoCuenta") ;
         SubmitImpl();
         aP0_ProgramNames=this.AV8ProgramNames;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new k2bisauthorizedactivitylist(context ).execute( ref  AV13ActivityList) ;
         AV8ProgramNames = new GXBaseCollection<SdtK2BProgramNames_ProgramName>( context, "ProgramName", "EstadoCuenta");
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'ADDPROGRAM' Routine */
         returnInSub = false;
         if ( AV15SecurityIndex > 0 )
         {
            if ( ((SdtK2BActivityList_K2BActivityListItem)AV13ActivityList.Item(AV15SecurityIndex)).gxTpr_Isauthorized )
            {
               AV9ProgramName = new SdtK2BProgramNames_ProgramName(context);
               AV9ProgramName.gxTpr_Name = AV10name;
               AV9ProgramName.gxTpr_Description = AV11description;
               AV9ProgramName.gxTpr_Link = AV12link;
               AV8ProgramNames.Add(AV9ProgramName, 0);
            }
         }
         else
         {
            AV9ProgramName = new SdtK2BProgramNames_ProgramName(context);
            AV9ProgramName.gxTpr_Name = AV10name;
            AV9ProgramName.gxTpr_Description = AV11description;
            AV9ProgramName.gxTpr_Link = AV12link;
            AV8ProgramNames.Add(AV9ProgramName, 0);
         }
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
         AV8ProgramNames = new GXBaseCollection<SdtK2BProgramNames_ProgramName>( context, "ProgramName", "EstadoCuenta");
         AV13ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "EstadoCuenta");
         AV9ProgramName = new SdtK2BProgramNames_ProgramName(context);
         AV10name = "";
         AV11description = "";
         AV12link = "";
         /* GeneXus formulas. */
      }

      private short AV15SecurityIndex ;
      private bool returnInSub ;
      private string AV10name ;
      private string AV11description ;
      private string AV12link ;
      private GXBaseCollection<SdtK2BProgramNames_ProgramName> aP0_ProgramNames ;
      private GXBaseCollection<SdtK2BProgramNames_ProgramName> AV8ProgramNames ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV13ActivityList ;
      private SdtK2BProgramNames_ProgramName AV9ProgramName ;
   }

}
