using Sitecore.Data;
using Sitecore.Diagnostics;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;

namespace Sitecore.Sharedsource.ItemNamingRules.Conditions
{
    public class WhenIsDescendant<T> : OperatorCondition<T> where T : RuleContext
    {
        private ID _itemId;

        public ID ItemId
        {
            get { return _itemId; }
            set
            {
                Assert.ArgumentNotNull(value, "value");
                _itemId = value;
            }
        }

        protected override bool Execute(T ruleContext)
        {
            Assert.ArgumentNotNull(ruleContext, "ruleContext");

            var contextItem = ruleContext.Item;
            if (contextItem != null)
            {
                if (contextItem.ID == ItemId) return false;

                while (contextItem != null)
                {
                    if (contextItem.ID == ItemId) return false;
                    if (null == contextItem.Parent) return false;
                    if (contextItem.Parent.ID == ItemId) return true;
                    if (contextItem.Parent.Axes.Level.Equals(0)) return false;
                    contextItem = contextItem.Parent;
                }
            }
            return false;
        }
    }
}