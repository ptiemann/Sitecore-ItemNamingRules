using System;
using System.Linq;

namespace Sitecore.Sharedsource.ItemNamingRules.Actions.DisplayNaming
{
    public abstract class ChangeDisplayNameAction<T> : Sitecore.Rules.Actions.RuleAction<T> where T : Sitecore.Rules.RuleContext
    {
        /// <summary>
        /// Changes DisplayName, unless it is a standard values item 
        /// or the start item for any of the managed Web sites.
        /// </summary>
        /// <param name="item">The item to rename.</param>
        /// <param name="newName">The new name for the item.</param>
        protected void ChangeDisplayName(Sitecore.Data.Items.Item item, string newName)
        {
            if (item.Template.StandardValues != null && item.ID == item.Template.StandardValues.ID)
            {
                return;
            }
            if (Sitecore.Configuration.Factory.GetSiteInfoList().Any(site => String.Compare(site.RootPath + site.StartItem, item.Paths.FullPath, true) == 0))
            {
                return;
            }
            using (new Sitecore.SecurityModel.SecurityDisabler())
            {
                using (new Sitecore.Data.Items.EditContext(item))
                {
                    using (new Sitecore.Data.Events.EventDisabler())
                    {
                        item.Appearance.DisplayName = newName;
                    }
                }
            }
        }
    }
}
