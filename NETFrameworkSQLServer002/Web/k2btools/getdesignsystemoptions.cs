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
   public class getdesignsystemoptions : GXProcedure
   {
      public getdesignsystemoptions( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public getdesignsystemoptions( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<SdtK2BAttributeValue_Item> aP0_DesignSystemOptions )
      {
         this.AV10DesignSystemOptions = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "EstadoCuenta") ;
         initialize();
         ExecutePrivate();
         aP0_DesignSystemOptions=this.AV10DesignSystemOptions;
      }

      public GXBaseCollection<SdtK2BAttributeValue_Item> executeUdp( )
      {
         execute(out aP0_DesignSystemOptions);
         return AV10DesignSystemOptions ;
      }

      public void executeSubmit( out GXBaseCollection<SdtK2BAttributeValue_Item> aP0_DesignSystemOptions )
      {
         this.AV10DesignSystemOptions = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "EstadoCuenta") ;
         SubmitImpl();
         aP0_DesignSystemOptions=this.AV10DesignSystemOptions;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10DesignSystemOptions = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "EstadoCuenta");
         AV9DesignSystemOption = new SdtK2BAttributeValue_Item(context);
         AV9DesignSystemOption.gxTpr_Attributename = "color-variant";
         AV9DesignSystemOption.gxTpr_Attributevalue = AV8WebSession.Get(AV9DesignSystemOption.gxTpr_Attributename);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9DesignSystemOption.gxTpr_Attributevalue)) )
         {
            AV9DesignSystemOption.gxTpr_Attributevalue = "dark";
         }
         AV10DesignSystemOptions.Add(AV9DesignSystemOption, 0);
         AV9DesignSystemOption = new SdtK2BAttributeValue_Item(context);
         AV9DesignSystemOption.gxTpr_Attributename = "base-color";
         AV9DesignSystemOption.gxTpr_Attributevalue = AV8WebSession.Get(AV9DesignSystemOption.gxTpr_Attributename);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9DesignSystemOption.gxTpr_Attributevalue)) )
         {
            AV9DesignSystemOption.gxTpr_Attributevalue = "green";
         }
         AV10DesignSystemOptions.Add(AV9DesignSystemOption, 0);
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
         AV10DesignSystemOptions = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "EstadoCuenta");
         AV9DesignSystemOption = new SdtK2BAttributeValue_Item(context);
         AV8WebSession = context.GetSession();
         /* GeneXus formulas. */
      }

      private IGxSession AV8WebSession ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> aP0_DesignSystemOptions ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> AV10DesignSystemOptions ;
      private SdtK2BAttributeValue_Item AV9DesignSystemOption ;
   }

}
