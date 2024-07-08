#!/bin/bash
set -e

curl -s "https://api.github.com/repos/kubernetes-sigs/kustomize/releases" | grep "browser_download.*darwin_amd64" | cut -d '"' -f 4 | sort -V | tail -n 1 | xargs curl -LJ | tar xvz -C src/Devantler.KustomizeCLI/assets/binaries kustomize
mv src/Devantler.KustomizeCLI/assets/binaries/kustomize src/Devantler.KustomizeCLI/assets/binaries/kustomize-darwin-amd64
chmod +x src/Devantler.KustomizeCLI/assets/binaries/kustomize-darwin-amd64
curl -s "https://api.github.com/repos/kubernetes-sigs/kustomize/releases" | grep "browser_download.*darwin_arm64" | cut -d '"' -f 4 | sort -V | tail -n 1 | xargs curl -LJ | tar xvz -C src/Devantler.KustomizeCLI/assets/binaries kustomize
mv src/Devantler.KustomizeCLI/assets/binaries/kustomize src/Devantler.KustomizeCLI/assets/binaries/kustomize-darwin-arm64
chmod +x src/Devantler.KustomizeCLI/assets/binaries/kustomize-darwin-arm64
curl -s "https://api.github.com/repos/kubernetes-sigs/kustomize/releases" | grep "browser_download.*linux_amd64" | cut -d '"' -f 4 | sort -V | tail -n 1 | xargs curl -LJ | tar xvz -C src/Devantler.KustomizeCLI/assets/binaries kustomize
mv src/Devantler.KustomizeCLI/assets/binaries/kustomize src/Devantler.KustomizeCLI/assets/binaries/kustomize-linux-amd64
chmod +x src/Devantler.KustomizeCLI/assets/binaries/kustomize-linux-amd64
curl -s "https://api.github.com/repos/kubernetes-sigs/kustomize/releases" | grep "browser_download.*linux_arm64" | cut -d '"' -f 4 | sort -V | tail -n 1 | xargs curl -LJ | tar xvz -C src/Devantler.KustomizeCLI/assets/binaries kustomize
mv src/Devantler.KustomizeCLI/assets/binaries/kustomize src/Devantler.KustomizeCLI/assets/binaries/kustomize-linux-arm64
chmod +x src/Devantler.KustomizeCLI/assets/binaries/kustomize-linux-arm64
