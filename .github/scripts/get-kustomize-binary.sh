#!/bin/bash
set -e

get_latest_release() {
  local repo=$1
  local os=$2
  local arch=$3
  curl --silent "https://api.github.com/repos/$repo/releases/latest" |
    grep '"name":' |
    grep "$os" |
    grep "$arch" |
    sed -E 's/.*"([^"]+)".*/\1/'
}

get() {
  local repo=$1
  local os=$2
  local arch=$3
  local binary=$4
  local target_dir=$5
  local target_name=$6
  local archiveType=$7
  latest_release=$(get_latest_release "$repo" "$os" "$arch")
  version=$(echo "$latest_release" | sed -E 's/.*_(v[0-9]+\.[0-9]+\.[0-9]+).*/\1/')
  local url="https://github.com/$repo/releases/download/kustomize/$version/$latest_release"

  echo "Downloading $target_name from $url"
  if [ "$archiveType" = "tar" ]; then
    curl -LJ "$url" | tar xvz -C "$target_dir" "$binary"
    mv "$target_dir/$binary" "${target_dir}/$target_name"
  elif [ "$archiveType" = "zip" ]; then
    curl -LJ "$url" -o "$target_dir/$target_name.zip"
    unzip -o "$target_dir/$target_name.zip" -d "$target_dir"
    mv "$target_dir/$binary" "${target_dir}/$target_name"
    rm "$target_dir/$target_name.zip"
  elif [ "$archiveType" = false ]; then
    curl -LJ "$url" -o "$target_dir/$target_name"
  fi
  chmod +x "$target_dir/$target_name"
}

repo="kubernetes-sigs/kustomize"

get "$repo" "darwin" "arm64" "kustomize" "Devantler.KustomizeCLI/runtimes/osx-arm64/native" "kustomize-osx-arm64" "tar"
get "$repo" "darwin" "amd64" "kustomize" "Devantler.KustomizeCLI/runtimes/osx-x64/native" "kustomize-osx-x64" "tar"
get "$repo" "linux" "arm64" "kustomize" "Devantler.KustomizeCLI/runtimes/linux-arm64/native" "kustomize-linux-arm64" "tar"
get "$repo" "linux" "amd64" "kustomize" "Devantler.KustomizeCLI/runtimes/linux-x64/native" "kustomize-linux-x64" "tar"
get "$repo" "windows" "amd64" "kustomize.exe" "Devantler.KustomizeCLI/runtimes/win-x64/native" "kustomize-win-x64.exe" "zip"
get "$repo" "windows" "arm64" "kustomize.exe" "Devantler.KustomizeCLI/runtimes/win-arm64/native" "kustomize-win-arm64.exe" "zip"
