using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTOs.Common
{
    public class Either<L, R>
    {
        private readonly L _left;
        private readonly R _right;
        private readonly bool _isRight;

        private Either(L left, R right, bool isRight)
        {
            _left = left;
            _right = right;
            _isRight = isRight;
        }

        public static Either<L, R> Left(L left) => new Either<L, R>(left, default, false);
        public static Either<L, R> Right(R right) => new Either<L, R>(default, right, true);

        public bool IsRight => _isRight;
        public bool IsLeft => !_isRight;

        public L LeftValue => _isRight ? throw new InvalidOperationException("No error present.") : _left;
        public R RightValue => !_isRight ? throw new InvalidOperationException("No success value present.") : _right;

        /* Functional composition to operate with monads*/
        public Either<L, T> Bind<T>(Func<R, Either<L, T>> func) => _isRight ? func(_right) : Either<L, T>.Left(_left);
    }
}
