set -e

HOST="$1"
PORT="$2"
shift 2

if [ "$1" = "--" ]; then
  shift
fi

echo "Waiting for TCP $HOST:$PORT"
while ! </dev/tcp/"$HOST"/"$PORT"; do
  echo "  (still waiting)"
  sleep 2
done

echo "$HOST:$PORT is available: running $*"
exec "$@"