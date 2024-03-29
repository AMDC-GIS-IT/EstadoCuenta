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
   public class k2bscadditem : GXProcedure
   {
      public k2bscadditem( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bscadditem( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_Item ,
                           bool aP1_SkipRepeated ,
                           ref GxSimpleCollection<string> aP2_StringCollection )
      {
         this.AV8Item = aP0_Item;
         this.AV10SkipRepeated = aP1_SkipRepeated;
         this.AV9StringCollection = aP2_StringCollection;
         initialize();
         ExecutePrivate();
         aP2_StringCollection=this.AV9StringCollection;
      }

      public GxSimpleCollection<string> executeUdp( string aP0_Item ,
                                                    bool aP1_SkipRepeated )
      {
         execute(aP0_Item, aP1_SkipRepeated, ref aP2_StringCollection);
         return AV9StringCollection ;
      }

      public void executeSubmit( string aP0_Item ,
                                 bool aP1_SkipRepeated ,
                                 ref GxSimpleCollection<string> aP2_StringCollection )
      {
         this.AV8Item = aP0_Item;
         this.AV10SkipRepeated = aP1_SkipRepeated;
         this.AV9StringCollection = aP2_StringCollection;
         SubmitImpl();
         aP2_StringCollection=this.AV9StringCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! AV10SkipRepeated )
         {
            AV9StringCollection.Add(AV8Item, 0);
         }
         else
         {
            if ( AV9StringCollection.IndexOf(AV8Item) == 0 )
            {
               AV9StringCollection.Add(AV8Item, 0);
            }
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

      private string AV8Item ;
      private bool AV10SkipRepeated ;
      private GxSimpleCollection<string> aP2_StringCollection ;
      private GxSimpleCollection<string> AV9StringCollection ;
   }

}
