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
   public class k2btoolsmsg : GXProcedure
   {
      public k2btoolsmsg( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2btoolsmsg( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_Message ,
                           short aP1_MessageType )
      {
         this.AV8Message = aP0_Message;
         this.AV9MessageType = aP1_MessageType;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( string aP0_Message ,
                                 short aP1_MessageType )
      {
         this.AV8Message = aP0_Message;
         this.AV9MessageType = aP1_MessageType;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10MsgText = "K2BToolsMessage:";
         if ( AV9MessageType == 0 )
         {
            AV10MsgText += "info:" + AV8Message;
            GX_msglist.addItem(AV10MsgText);
         }
         else if ( AV9MessageType == 3 )
         {
            AV10MsgText += "success:" + AV8Message;
            GX_msglist.addItem(AV10MsgText);
         }
         else if ( AV9MessageType == 2 )
         {
            AV10MsgText += "error:" + AV8Message;
            GX_msglist.addItem(AV10MsgText);
         }
         else if ( AV9MessageType == 1 )
         {
            AV10MsgText += "warning:" + AV8Message;
            GX_msglist.addItem(AV10MsgText);
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
         AV10MsgText = "";
         /* GeneXus formulas. */
      }

      private short AV9MessageType ;
      private string AV8Message ;
      private string AV10MsgText ;
   }

}
