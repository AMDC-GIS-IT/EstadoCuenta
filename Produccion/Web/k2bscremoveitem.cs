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
   public class k2bscremoveitem : GXProcedure
   {
      public k2bscremoveitem( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bscremoveitem( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_Item ,
                           ref GxSimpleCollection<string> aP1_CollectionString )
      {
         this.AV9Item = aP0_Item;
         this.AV8CollectionString = aP1_CollectionString;
         initialize();
         ExecutePrivate();
         aP1_CollectionString=this.AV8CollectionString;
      }

      public GxSimpleCollection<string> executeUdp( string aP0_Item )
      {
         execute(aP0_Item, ref aP1_CollectionString);
         return AV8CollectionString ;
      }

      public void executeSubmit( string aP0_Item ,
                                 ref GxSimpleCollection<string> aP1_CollectionString )
      {
         this.AV9Item = aP0_Item;
         this.AV8CollectionString = aP1_CollectionString;
         SubmitImpl();
         aP1_CollectionString=this.AV8CollectionString;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10Index = (short)(AV8CollectionString.IndexOf(AV9Item));
         if ( AV10Index > 0 )
         {
            AV8CollectionString.RemoveItem(AV10Index);
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
         /* GeneXus formulas. */
      }

      private short AV10Index ;
      private string AV9Item ;
      private GxSimpleCollection<string> aP1_CollectionString ;
      private GxSimpleCollection<string> AV8CollectionString ;
   }

}
