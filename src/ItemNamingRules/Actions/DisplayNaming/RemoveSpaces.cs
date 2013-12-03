using System.Text.RegularExpressions;

namespace Sitecore.Sharedsource.ItemNamingRules.Actions.DisplayNaming
{
    /// <summary>
    /// Rules engine action to replace invalid characters in item names.
    /// </summary>
    /// <typeparam name="T">Type providing rule context.</typeparam>
    // TODO: Created Sitecore Item "/sitecore/system/Settings/Rules/Common/Actions/RemoveSpaces" when creating RemoveSpaces class. Fix Title field.

    public class RemoveSpaces<T> : ChangeDisplayNameAction<T> where T : Sitecore.Rules.RuleContext
    {
        /// <summary>
        /// Action implementation.
        /// </summary>
        /// <param name="ruleContext">The rule context.</param>
        public override void Apply([NotNull] T ruleContext)
        {
            string newName = Regex.Replace(ruleContext.Item.Name, @"\s", "");
            if (ruleContext.Item.DisplayName != newName)
            {
                this.ChangeDisplayName(ruleContext.Item, newName);
            }
        }
    }
}