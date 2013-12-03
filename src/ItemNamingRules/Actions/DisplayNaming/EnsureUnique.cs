using System;
using Sitecore.Rules;

namespace Sitecore.Sharedsource.ItemNamingRules.Actions.DisplayNaming
{
    public class EnsureUnique<T> : ChangeDisplayNameAction<T> where T : RuleContext
    {
        /// <summary>
        /// Gets or sets the maximum allowed length for item DisplayNames.
        /// </summary>
        public int MaxLength
        {
            get;
            set;
        }

        /// <summary>
        /// Action implementation.
        /// </summary>
        /// <param name="ruleContext">The rule context.</param>
        public override void Apply(T ruleContext)
        {
            if (ruleContext.Item.DisplayName.Length > this.MaxLength)
            {
                ChangeDisplayName(
                  ruleContext.Item,
                  ruleContext.Item.DisplayName.Substring(0, this.MaxLength));
            }

            bool unique;

            do
            {
                unique = true;

                foreach (Sitecore.Data.Items.Item child
                  in ruleContext.Item.Parent.Children)
                {
                    if (child.ID.Equals(ruleContext.Item.ID)
                      || !child.DisplayName.Equals(ruleContext.Item.Key))
                    {
                        continue;
                    }

                    unique = false;
                    string strDateTime = Sitecore.DateUtil.ToIsoDate(
                      DateTime.Now).ToLower();
                    string newName = ruleContext.Item.DisplayName + strDateTime;

                    if (this.MaxLength > 0 && newName.Length > this.MaxLength)
                    {
                        newName = newName.Substring(
                          0,
                          this.MaxLength - (strDateTime.Length + 1)) + strDateTime;
                    }

                    this.ChangeDisplayName(ruleContext.Item, newName);
                    break;
                }
            }
            while (!unique);
        }
    }
}