using System;
using System.Collections.Generic;

namespace Carubbi.SlotCard
{
    public class PriceEventArgs : EventArgs
    {
        public int LineNumber { get; set; }
        public string PriceName { get; set; }
        public int PriceValue { get; set; }
    }

    public delegate void PriceHandler(object sender, PriceEventArgs e);

    public class Payer
    {
        private decimal _variantPercent;

        public Payer()
        {
            GamesInCollectMode = SwapModeCountDown();
        }

        public int GamesInCollectMode { get; private set; }

        public int GamesInDeliverMode { get; private set; }

        public bool IsInDeliverMode { get; private set; }

        private int SwapModeCountDown()
        {
            var random = new Random();
            return random.Next(1, 20);
        }

        public event PriceHandler OnPayPrice;

        internal int Pay(List<Line> lines, int coins, bool raiseEvents)
        {
            var coinsToPay = 0;
            var lineCount = 1;
            foreach (var l in lines)
            {
                var resultPrice = l.Result();
                coinsToPay += resultPrice * coins;
                if (resultPrice > 0 && raiseEvents && OnPayPrice != null)
                    OnPayPrice(this,
                        new PriceEventArgs
                        {
                            LineNumber = lineCount,
                            PriceName = l.PriceName,
                            PriceValue = resultPrice * coins
                        });

                lineCount++;
            }

            return coinsToPay;
        }

        internal int Pay(List<Line> lines, int coins)
        {
            return Pay(lines, coins, true);
        }

        internal bool ValidPay(List<Line> lines, int coins, int totalCoinsReceived, int totalCoinsReturneds,
            decimal percentGain)
        {
            if (_variantPercent == 0)
                GeneratePercentGain(percentGain);

            bool validPay;

            var coinsToPay = Pay(lines, coins, false);

            if (coinsToPay > 0)
            {
                var percentToGain = Convert.ToDecimal(totalCoinsReturneds + coinsToPay) * 100 /
                                    Convert.ToDecimal(totalCoinsReceived);
                validPay = _variantPercent >= percentToGain;
            }
            else
            {
                if (!IsInDeliverMode)
                    GamesInCollectMode--;
                validPay = true;
            }

            if (validPay && coinsToPay > 0)
            {
                if (!IsInDeliverMode)
                    return SwitchToDeliveryMode(percentGain);
                return SwitchToCollectMode(percentGain);
            }

            if (coinsToPay == 0)
            {
                if (!IsInDeliverMode)
                    SwitchToDeliveryMode(percentGain);
                else
                    SwitchToCollectMode(percentGain);
                return true;
            }

            if (!IsInDeliverMode)
                SwitchToDeliveryMode(percentGain);
            else
                SwitchToCollectMode(percentGain);
            return false;
        }

        private void GeneratePercentGain(decimal percentGain)
        {
            var rnd = new Random();
            var maxPercentGain = Convert.ToInt32(Math.Floor(percentGain));
            var minPercentGain = maxPercentGain - 20;
            _variantPercent = rnd.Next(minPercentGain > 0 ? minPercentGain : 0, maxPercentGain);
        }


        private bool SwitchToDeliveryMode(decimal percentGain)
        {
            if (GamesInCollectMode == 0)
            {
                GamesInDeliverMode = SwapModeCountDown();
                GeneratePercentGain(percentGain);
                IsInDeliverMode = true;
                return true;
            }

            return false;
        }


        private bool SwitchToCollectMode(decimal percentGain)
        {
            GamesInDeliverMode--;
            if (GamesInDeliverMode == 0)
            {
                GamesInCollectMode = SwapModeCountDown();
                GeneratePercentGain(percentGain);
                IsInDeliverMode = false;
                return false;
            }

            return true;
        }
    }
}