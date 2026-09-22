# Changelog

## [1.7.0](https://github.com/run-llama/llama-parse-csharp/compare/v1.6.0...v1.7.0) (2026-09-08)


### ⚠ BREAKING CHANGES

* **classifier:** the classify v1 job methods (`client.Classifier.Jobs.Create`, `.List`, `.Get`, `.GetResults`) are removed. The `/api/v1/classifier/jobs*` routes were unpublished from the API surface; use `client.Classify` instead.

### Features

* **api:** add paginated GET /api/v2/pipelines, deprecate the v1 list ([#25587](https://github.com/run-llama/llama-parse-csharp/issues/25587)) ([5febd21](https://github.com/run-llama/llama-parse-csharp/commit/5febd21980a6e8226756efd9c82c541c17d9c08b))
* **api:** map DELETE /api/v2/parse/{job_id} and GET /api/v2/pipelines into the SDKs (LI-9569) ([cefce34](https://github.com/run-llama/llama-parse-csharp/commit/cefce3487e69a9afb2bb2796614ffe4e23b82fcc))
* **llamaparse:** agentic 2026-09-07 — heading rules: own-line titles, furniture, document-wide levels ([#26146](https://github.com/run-llama/llama-parse-csharp/issues/26146)) ([1aa0818](https://github.com/run-llama/llama-parse-csharp/commit/1aa0818b7271a9276bb01b90754b7b9e15ea84d1))


### Chores

* **sync:** resolve back-sync conflicts with production ([b934867](https://github.com/run-llama/llama-parse-csharp/commit/b9348676d60bc5621f6cec704b196171ebc9556d))


### Documentation

* **extract:** drop the experimental label and removal caveat from turbo ([#25539](https://github.com/run-llama/llama-parse-csharp/issues/25539)) ([595ce2b](https://github.com/run-llama/llama-parse-csharp/commit/595ce2b6ac88666acde7297549a60c083aa7df7a))

## [1.6.0](https://github.com/run-llama/llama-parse-csharp/compare/v1.5.1...v1.6.0) (2026-08-28)


### Features

* **extract:** publish the turbo tier on the public API surface (LI-8873) ([66ba210](https://github.com/run-llama/llama-parse-csharp/commit/66ba21052aaa2e29a28148a40793cd9040d225b0))

## [1.5.1](https://github.com/run-llama/llama-parse-csharp/compare/v1.5.0...v1.5.1) (2026-08-14)


### Bug Fixes

* **ci:** restore C# production backsync ([0a5e757](https://github.com/run-llama/llama-parse-csharp/commit/0a5e757d7a2fb7729724bc4bcc41f7217244bab9))
* **ci:** restore C# promotion transport ([14b74b5](https://github.com/run-llama/llama-parse-csharp/commit/14b74b5ee14ec3a5282e283c3e8cf224496eaff0))
* **ci:** restore CI_BOT release token ([42cecfb](https://github.com/run-llama/llama-parse-csharp/commit/42cecfb247bcfe2c39c9b89271e534a19d493bb2))
* **ci:** use NuGet policy creator ([b01cd84](https://github.com/run-llama/llama-parse-csharp/commit/b01cd8491248a3de2a5db60025a3c3d737415d08))
* **csharp:** restore release and promotion custom code ([fdc0acd](https://github.com/run-llama/llama-parse-csharp/commit/fdc0acdc313700b8b1a19e646192ed5f873df962))
* **docs:** restore LlamaIndex license attribution ([7574bb0](https://github.com/run-llama/llama-parse-csharp/commit/7574bb051c0ba114df4cacc00037ec5720b36130))
* **docs:** restore LlamaIndex security contact ([8eb1f24](https://github.com/run-llama/llama-parse-csharp/commit/8eb1f24367fee42a098e2d2d0793ef9db23cc90c))
* **release:** preserve C# release history ([a7cf4b6](https://github.com/run-llama/llama-parse-csharp/commit/a7cf4b6212766b022c9d36313d254ac4e1e3a7a0))

## [1.5.0](https://github.com/run-llama/llama-parse-csharp/compare/v0.0.1...v1.5.0) (2026-08-14)


### Chores

* release 1.5.0 ([e7b6685](https://github.com/run-llama/llama-parse-csharp/commit/e7b668504ade23583b67ffb67bb12a3a88fe6c4f))
