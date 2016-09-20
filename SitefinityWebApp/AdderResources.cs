using System;
using System.Linq;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Localization.Data;

namespace SitefinityWebApp
{
    /// <summary>
    /// Sitefinity localizable strings
    /// </summary>
    /// <remarks>
    /// You can use Sitefinity Thunder to edit this file.
    /// To do this, open the file's context menu and select Edit with Thunder.
    /// 
    /// If you wish to install this as a part of a custom module,
    /// add this to the module's Initialize method:
    /// App.WorkWith()
    ///     .Module(ModuleName)
    ///     .Initialize()
    ///         .Localization<AdderResources>();
    /// </remarks>
    /// <see cref="http://www.sitefinity.com/documentation/documentationarticles/developers-guide/how-to/how-to-import-events-from-facebook/creating-the-resources-class"/>
    [ObjectInfo("AdderResources", ResourceClassId = "AdderResources", Title = "AdderResourcesTitle", TitlePlural = "AdderResourcesTitlePlural", Description = "AdderResourcesDescription")]
    public class AdderResources : Resource
    {
        #region Construction
        /// <summary>
        /// Initializes new instance of <see cref="AdderResources"/> class with the default <see cref="ResourceDataProvider"/>.
        /// </summary>
        public AdderResources()
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="AdderResources"/> class with the provided <see cref="ResourceDataProvider"/>.
        /// </summary>
        /// <param name="dataProvider"><see cref="ResourceDataProvider"/></param>
        public AdderResources(ResourceDataProvider dataProvider) : base(dataProvider)
        {
        }
        #endregion

        #region Class Description
        /// <summary>
        /// The title of the class.
        /// </summary>
        /// <value>AdderResources labels</value>
        [ResourceEntry("AdderResourcesTitle",
            Value = "AdderResources labels",
            Description = "The title of this class.",
            LastModified = "2016/09/20")]
        public string AdderResourcesTitle
        {
            get
            {
                return this["AdderResourcesTitle"];
            }
        }

        /// <summary>
        /// The plural title of this class.
        /// </summary>
        /// <value>AdderResources labels</value>
        [ResourceEntry("AdderResourcesTitlePlural",
            Value = "AdderResources labels",
            Description = "The plural title of this class.",
            LastModified = "2016/09/20")]
        public string AdderResourcesTitlePlural
        {
            get
            {
                return this["AdderResourcesTitlePlural"];
            }
        }

        /// <summary>
        /// The description of this class.
        /// </summary>
        /// <value>Contains localizable resources.</value>
        [ResourceEntry("AdderResourcesDescription",
            Value = "Contains localizable resources.",
            Description = "The description of this class.",
            LastModified = "2016/09/20")]
        public string AdderResourcesDescription
        {
            get
            {
                return this["AdderResourcesDescription"];
            }
        }
        #endregion

        #region Resources

        [ResourceEntry("SumLabel",
    Value = "The sum of the values is:",
    Description = "This is the label for the sum",
    LastModified = "2016/09/20")]
        public string SumLabel
        {
            get
            {
                return this["SumLabel"];
            }
        }

        #endregion
    }
}