﻿namespace DomainModel.Features
{
    public class CurrencyOfMarket
    {
        public CurrencyOfMarket(Currency currency, Market market) :
            this(currency, market, 0)
        {
        }

        public CurrencyOfMarket(Currency currency, Market market, double txFee) :
            this(currency, market, txFee, true)
        {
        }

        public CurrencyOfMarket(Currency currency, Market market, double txFee, bool isActive) :
            this(currency, market, txFee, isActive, null, 0)
        {
        }

        public CurrencyOfMarket(Currency currency, Market market, double txFee, bool isActive, CryptoAddress baseAddress) :
            this(currency, market, txFee, isActive, baseAddress, 0)
        {
        }

        public CurrencyOfMarket(Currency currency, Market market, double txFee, bool isActive, CryptoAddress baseAddress, int minConfirmation)
        {
            Currency = currency;
            Market = market;
            TxFee = txFee;
            IsActive = isActive;
            BaseAddress = baseAddress;
            MinConfirmation = minConfirmation;
        }

        public Currency Currency { get; }
        public Market Market { get; }
        public double TxFee { get; set; }
        public bool IsActive { get; set; }
        public CryptoAddress BaseAddress { get; set; }
        public int MinConfirmation { get; set; }
    }
}