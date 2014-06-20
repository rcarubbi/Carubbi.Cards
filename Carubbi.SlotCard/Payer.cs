using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public Payer()
        {
            _gamesInCollectMode = SwapModeCountDown();
        }

        private int SwapModeCountDown()
        {
            Random random = new Random();
            return random.Next(1, 20);
        }

        public event PriceHandler OnPayPrice;

        internal int Pay(List<Line> lines, int coins, bool raiseEvents)
        {
            int coinsToPay = 0;
            int lineCount = 1;
            foreach (Line l in lines)
            {
                int resultPrice = l.Result();
                coinsToPay += resultPrice * coins;
                if (resultPrice > 0 && raiseEvents && OnPayPrice != null)
                    OnPayPrice(this, new PriceEventArgs() { LineNumber = lineCount, PriceName = l.PriceName, PriceValue = resultPrice * coins });

                lineCount++;
            }
            return coinsToPay;
        }

        internal int Pay(List<Line> lines, int coins)
        {
            return Pay(lines, coins, true);
        }

        private int _gamesInCollectMode;
        
        private int _gamesInDeliverMode;
        
        private bool _isInDeliverMode = false;

        public int GamesInCollectMode
        {
            get { return _gamesInCollectMode; }
        }

        public int GamesInDeliverMode
        {
            get { return _gamesInDeliverMode; }
        }

        public bool IsInDeliverMode
        {
            get
            {
                return _isInDeliverMode;
            }
        }
        private decimal _variantPercent;

        internal bool ValidPay(List<Line> lines, int coins, int totalCoinsReceived, int totalCoinsReturneds, decimal percentGain)
        {
            if (_variantPercent == 0)
                GeneratePercentGain(percentGain);

            bool validPay;

            int coinsToPay = Pay(lines, coins, false);

            if (coinsToPay > 0)
            {
                decimal percentToGain = Convert.ToDecimal(totalCoinsReturneds + coinsToPay) * 100 / Convert.ToDecimal(totalCoinsReceived);
                validPay = _variantPercent >= percentToGain;
            }
            else
            {
                if (!_isInDeliverMode)
                    _gamesInCollectMode--;
                validPay = true;
            }

            if (validPay && coinsToPay > 0)
            {
                if (!_isInDeliverMode)
                {
                    if (_gamesInCollectMode == 0)
                    {
                        _gamesInDeliverMode = SwapModeCountDown();
                        GeneratePercentGain(percentGain);
                        _isInDeliverMode = true;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    _gamesInDeliverMode--;
                    if (_gamesInDeliverMode == 0)
                    {
                        _gamesInCollectMode = SwapModeCountDown();
                        GeneratePercentGain(percentGain);
                        _isInDeliverMode = false;
                        return false;
                    }
                    else
                        return true;
                }
            }
            else if (coinsToPay == 0)
            {
                return true;
            }
            else
                return false;
        }

        private void GeneratePercentGain(decimal percentGain)
        {
            Random rnd = new Random();
            int maxPercentGain = Convert.ToInt32(Math.Floor(percentGain));
            int minPercentGain = maxPercentGain - 20;
            _variantPercent = rnd.Next(minPercentGain > 0 ? minPercentGain : 0, maxPercentGain);
        }

    }

}
