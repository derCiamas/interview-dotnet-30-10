#!/usr/bin/env bash
set -Eeuo pipefail

base_url="${1:-http://127.0.0.1:5080}"
body="$(mktemp)"
trap 'rm -f -- "$body"' EXIT

assert_status() {
  local path="$1"
  local expected="$2"
  local actual
  actual="$(curl --silent --show-error --max-time 10 \
    --output "$body" --write-out '%{http_code}' "$base_url$path")"
  if [[ "$actual" != "$expected" ]]; then
    printf 'FAIL %s: expected %s, got %s\n' "$path" "$expected" "$actual" >&2
    cat "$body" >&2
    exit 1
  fi
  printf 'PASS %s: %s\n' "$path" "$actual"
}

assert_status /products/1 200
grep -Fq '"id":1' "$body"
grep -Fq '"name":"Keyboard"' "$body"
assert_status /products/2 200
grep -Fq '"id":2' "$body"
assert_status /products/999 404
assert_status /products/not-an-int 404
