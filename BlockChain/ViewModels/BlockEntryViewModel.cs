﻿using BlockChain.Models.BlockChain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.ViewModels
{
    public class BlockEntryViewModel
    {

        public Block block;

        public string Index { get; set; }
        public string Date { get; set; }
        public string PreviousHash { get; set; }
        public string Hash { get; set; }
        public string Nonce { get; set; }
        public string Data { get; set; }


        public BlockEntryViewModel(Block block)
        {
            if (block.index == 0)
                Index = "Genesis Block";
            else
                Index = $"Block {block.index}";

            Date = $"{block.date.ToShortDateString()}  :  {block.date.ToShortTimeString()}";
            PreviousHash = $"{block.previousHash}";
            Hash = $"{block.hash}";
            Nonce = $"{block.nonce}";

            string tempData = "";
            for(int i=0;i<block.transactions.Count;i++)
            {
                tempData = string.Concat(tempData, $"TRANSACTION\nSender: {block.transactions[i].sender}\nReceiver{block.transactions[i].receiver}\nAmount{block.transactions[i].amount}\n\n");
            }
            Data = tempData;
        }
    }
}
