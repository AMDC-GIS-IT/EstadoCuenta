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
   public class k2bgetuseravatar : GXProcedure
   {
      public k2bgetuseravatar( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bgetuseravatar( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out string aP0_UserImage )
      {
         this.AV8UserImage = "" ;
         initialize();
         ExecutePrivate();
         aP0_UserImage=this.AV8UserImage;
      }

      public string executeUdp( )
      {
         execute(out aP0_UserImage);
         return AV8UserImage ;
      }

      public void executeSubmit( out string aP0_UserImage )
      {
         this.AV8UserImage = "" ;
         SubmitImpl();
         aP0_UserImage=this.AV8UserImage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8UserImage = "";
         AV9Userimage_GXI = "";
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
         AV8UserImage = "";
         AV9Userimage_GXI = "";
         /* GeneXus formulas. */
      }

      private string AV9Userimage_GXI ;
      private string AV8UserImage ;
      private string aP0_UserImage ;
   }

}
