using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Shell.Controls.RichTextEditor;

namespace Galiana.SitecoreEditorConfigurator
{
    public class EditorConfiguration : Sitecore.Shell.Controls.RichTextEditor.EditorConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Sitecore.Shell.Controls.RichTextEditor.EditorConfiguration" /> class.
        /// </summary>
        /// <param name="profile">
        /// The profile.
        /// </param>
        public EditorConfiguration(Item profile) : base(profile) { }
        

        /// <summary>
        /// Builds the font sizes.
        /// </summary>
        protected override void SetupFontSizes()
        {
            int num;
            
            Item Sizesitem = this.Profile.Children["Real Font Sizes"];
            Item RealSizesitem = this.Profile.Children["Real Font Sizes"];
            if (Sizesitem != null)
            {
                this.Editor.FontSizes.Clear();
                foreach (Item child in Sizesitem.Children)
                {
                    string str = child["Value"];
                    this.Editor.FontSizes.Add(str);
                }
            }
            if (RealSizesitem != null)
            {
                this.Editor.RealFontSizes.Clear();
                foreach (Item child in RealSizesitem.Children)
                {
                    string str = child["Value"];
                    this.Editor.RealFontSizes.Add(str);
                }
            }
            if (Sizesitem != null && RealSizesitem != null)
                Log.SingleWarn("Relative and real Font sizes have been configured on profile " + this.Profile.DisplayName + ". Only real sizes will be shown.", this);
        }
    }
}
