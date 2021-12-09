namespace Volo.HDShop.Settings
{
    public static class HDShopSettings
    {
        public const string Prefix = "HDShop";

        /* Add constants for setting names. Example:
         * public const string MySettingName = GroupName + ".MySettingName";
         */
         //Add your own setting names here. Example:
        /// <summary>
        /// 当前机器码（小于订单机器码位数值）
        /// </summary>
        public const string OrderCodeMachine = Prefix + ".OrderCodeMachine";
        /// <summary>
        /// 订单机器码位数
        /// </summary>
        public const string OrderCodeMachineBit = Prefix + ".OrderCodeMachineBit";
        /// <summary>
        /// 订单序号位数
        /// </summary>
        public const string OrderCodeSequenceBit = Prefix + ".OrderCodeSequenceBit";
    }
}