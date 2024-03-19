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
   public class k2bsessionget : GXProcedure
   {
      public k2bsessionget( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bsessionget( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_SessionItem ,
                           out string aP1_SessionData )
      {
         this.AV10SessionItem = aP0_SessionItem;
         this.AV8SessionData = "" ;
         initialize();
         ExecutePrivate();
         aP1_SessionData=this.AV8SessionData;
      }

      public string executeUdp( string aP0_SessionItem )
      {
         execute(aP0_SessionItem, out aP1_SessionData);
         return AV8SessionData ;
      }

      public void executeSubmit( string aP0_SessionItem ,
                                 out string aP1_SessionData )
      {
         this.AV10SessionItem = aP0_SessionItem;
         this.AV8SessionData = "" ;
         SubmitImpl();
         aP1_SessionData=this.AV8SessionData;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8SessionData = AV9Session.Get(AV10SessionItem);
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
         AV8SessionData = "";
         AV9Session = context.GetSession();
         /* GeneXus formulas. */
      }

      private string AV10SessionItem ;
      private string AV8SessionData ;
      private IGxSession AV9Session ;
      private string aP1_SessionData ;
   }

}
