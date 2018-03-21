using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HanoiGame.Models.Entities
{
    public class Hanoi
    {
        public Stack _1 = new Stack();
        public Stack _2 = new Stack();
        public Stack _3 = new Stack();

        public int total = 0;

        public Hanoi() {  _1.Push(4); _1.Push(3); _1.Push(2); _1.Push(1); }

        public void start() { take(1); }

        public void put(int number)
        {

            int actual = findPalo(number);

            if (even(number))
            {
                if (actual  == 1)
                {
                    getPalo(actual + 2).Push(getPalo(actual).Pop());
                }
                else
                {
                    getPalo(actual - 1).Push(getPalo(actual).Pop());
                }
            }
            else
            {
                if (actual  == 3) {
                    getPalo(actual - 2).Push(getPalo(actual).Pop());
                } else {
                    getPalo(actual + 1).Push(getPalo(actual).Pop());
                }
            }

        }

        public void take(int movimiento, int divisor = 1, int valor = 1)
        {
            if (_1.Count == 0 && (_2.Count == 0 || _3.Count == 0))
            {
                total = movimiento - 1;
            }
            else
            {
                if (odd(movimiento / divisor)) {
                    put(valor);
                    take(movimiento + 1);
                }
                else take(movimiento, 2 * valor, valor + 1);
            }

        }

        public int findPalo(int number) { return _1.Contains(number) ? 1 : (_2.Contains(number) ? 2 : 3); }
        public Stack getPalo(int index) { return index == 1 ? _1 : (index == 2 ? _2 : _3); }
        public bool even(int number) { return (number % 2 == 0); }
        public bool odd(int number) { return (number % 2 != 0); }
    }
}
