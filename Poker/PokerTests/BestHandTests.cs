﻿using NUnit.Framework;
using Poker.Service;
using Poker.Service.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerTests
{
    [TestFixture]
    class BestHandTests
    {
        private static Card[] flushCards = { new Card(3, 'H'), new Card(4, 'H'), new Card(3, 'S'), new Card(4, 'D'), new Card(9, 'H'), new Card(6, 'H'), new Card(12, 'H') };
        private static Card[] straightCards = { new Card(3, 'H'), new Card(4, 'H'), new Card(5, 'S'), new Card(10, 'D'), new Card(6, 'C'), new Card(6, 'H'), new Card(7, 'D') };
        private static Card[] aceLowStraightCards = { new Card(3, 'H'), new Card(4, 'H'), new Card(5, 'S'), new Card(14, 'D'), new Card(2, 'C'), new Card(9, 'H'), new Card(12, 'D') };
        private static Card[] straightFlushCardsNoDupl = { new Card(3, 'H'), new Card(4, 'H'), new Card(5, 'H'), new Card(10, 'S'), new Card(9, 'S'), new Card(6, 'H'), new Card(7, 'H') };
        private static Card[] straightFlushCardsWithDupl = { new Card(3, 'H'), new Card(4, 'H'), new Card(5, 'H'), new Card(6, 'S'), new Card(7, 'S'), new Card(6, 'H'), new Card(7, 'H') };
        private static Card[] pairCards = { new Card(3, 'H'), new Card(3, 'S'), new Card(5, 'H'), new Card(10, 'S'), new Card(11, 'S'), new Card(9, 'S'), new Card(7, 'D') };
        private static Card[] twoPairCards = { new Card(3, 'H'), new Card(3, 'S'), new Card(5, 'H'), new Card(5, 'S'), new Card(11, 'S'), new Card(7, 'S'), new Card(7, 'D') };
        private static Card[] setCards = { new Card(3, 'H'), new Card(5, 'D'), new Card(5, 'H'), new Card(5, 'S'), new Card(11, 'S'), new Card(9, 'S'), new Card(7, 'D') };
        private static Card[] fullHouseCards = { new Card(5, 'H'), new Card(5, 'D'), new Card(5, 'S'), new Card(3, 'S'), new Card(3, 'H'), new Card(9, 'S'), new Card(7, 'D') };
        private static Card[] quadCards = { new Card(14, 'C'), new Card(14, 'D'), new Card(10, 'S'), new Card(10, 'C'), new Card(10, 'H'), new Card(10, 'D'), new Card(3, 'H') };
        [Test]
        public void ChecksForFlush()
        {
            User player = new User("Gosho", 1000);
            player.HandAndBoard = flushCards.ToList();
            BestHand.SetBestCards(player);

            Assert.AreEqual(6, player.BestHand.Value);
        }
        [Test]
        public void ChecksForStraight()
        {
            User player = new User("Gosho", 1000);
            player.HandAndBoard = straightCards.ToList();
            BestHand.SetBestCards(player);

            Assert.AreEqual(5, player.BestHand.Value);
        }
        [Test]
        public void ChecksForStraightWithAceLow()
        {
            User player = new User("Gosho", 1000);
            player.HandAndBoard = aceLowStraightCards.ToList();
            BestHand.SetBestCards(player);

            Assert.AreEqual(5, player.BestHand.Value);
            Assert.AreEqual(14, player.BestHand.BestCards.Last().Number);
        }
        [Test]
        public void CheckForStraightFlushNoDuplicates()
        {
            User player = new User("Gosho", 1000);
            player.HandAndBoard = straightFlushCardsNoDupl.ToList();
            BestHand.SetBestCards(player);

            Assert.AreEqual(9, player.BestHand.Value);
        }
        [Test]
        public void CheckForStraightFlushWithDuplicates()
        {
            User player = new User("Gosho", 1000);
            player.HandAndBoard = straightFlushCardsWithDupl.ToList();
            BestHand.SetBestCards(player);

            Assert.AreEqual(9, player.BestHand.Value);
        }
        [Test]
        public void CheckForPair()
        {
            User player = new User("Gosho", 1000);
            player.HandAndBoard = pairCards.ToList();
            BestHand.SetBestCards(player);

            Assert.AreEqual(2, player.BestHand.Value);
        }
        [Test]
        public void CheckForTwoPair()
        {
            User player = new User("Gosho", 1000);
            player.HandAndBoard = twoPairCards.ToList();
            BestHand.SetBestCards(player);

            Assert.AreEqual(3, player.BestHand.Value);
        }
        [Test]
        public void CheckForSet()
        {
            User player = new User("Gosho", 1000);
            player.HandAndBoard = setCards.ToList();
            BestHand.SetBestCards(player);

            Assert.AreEqual(4, player.BestHand.Value);
        }
        [Test]
        public void CheckForFullHouse()
        {
            User player = new User("Gosho", 1000);
            player.HandAndBoard = fullHouseCards.ToList();
            BestHand.SetBestCards(player);

            Assert.AreEqual(7, player.BestHand.Value);
        }
        [Test]
        public void CheckForQuad()
        {
            User player = new User("Gosho", 1000);
            player.HandAndBoard = quadCards.ToList();
            BestHand.SetBestCards(player);

            Assert.AreEqual(8, player.BestHand.Value);
        } 
    }
}