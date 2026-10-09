# Changelog

## [1.9.0](https://github.com/run-llama/llama-parse-csharp/compare/v1.8.0...v1.9.0) (2026-10-09)


### Features

* **sdk:** move Index v2 indexes, retrieval and chat out of beta (PROD-10331) ([0f0828a](https://github.com/run-llama/llama-parse-csharp/commit/0f0828ad999a5f3820315385c2f7bea63e4be711))
* **sdk:** publish Verify as client.alpha.verify (PROD-10334) ([6a4394f](https://github.com/run-llama/llama-parse-csharp/commit/6a4394fae84f4e0606a572ebcca565ac840d1206))

## [1.8.0](https://github.com/run-llama/llama-parse-csharp/compare/v1.7.0...v1.8.0) (2026-10-07)


### Features

* add redline prompt changes to new prod version ([#27635](https://github.com/run-llama/llama-parse-csharp/issues/27635)) ([d668fe7](https://github.com/run-llama/llama-parse-csharp/commit/d668fe7f5d348434d515027b6cbcab7bde8260ba))
* **chat:** let a chat session refuse queries from its share link ([#27012](https://github.com/run-llama/llama-parse-csharp/issues/27012)) ([dec92c1](https://github.com/run-llama/llama-parse-csharp/commit/dec92c169284d56dd634348faa9392f1ec45f2a2))
* **parse:** add detected_form_types to the per-page enriched forms output ([#26052](https://github.com/run-llama/llama-parse-csharp/issues/26052)) ([81df468](https://github.com/run-llama/llama-parse-csharp/commit/81df468d7e6896b7a09544ade5617d400f552b47))
* **parse:** add option to include hidden PPTX slides ([#27938](https://github.com/run-llama/llama-parse-csharp/issues/27938)) ([f188e33](https://github.com/run-llama/llama-parse-csharp/commit/f188e3364e4b732d8c8a46dc7707d821532577a5))
* **parse:** agentic 2026-09-09 — cache-stable prompt order + Flash Lite MINIMAL thinking ([#26273](https://github.com/run-llama/llama-parse-csharp/issues/26273)) ([f820ba4](https://github.com/run-llama/llama-parse-csharp/commit/f820ba4412152f77c92a5c6c9a3ff9065a3dafaf))
* **parse:** apply watermark_handling to text output; add watermark e2e test ([#27932](https://github.com/run-llama/llama-parse-csharp/issues/27932)) ([a70e24f](https://github.com/run-llama/llama-parse-csharp/commit/a70e24f77b258a0a425158f03e3a1746d37455df))
* **parse:** display enriched Forms granular highlights ([#26366](https://github.com/run-llama/llama-parse-csharp/issues/26366)) ([5c07972](https://github.com/run-llama/llama-parse-csharp/commit/5c0797292f93f3a67cde2b5feebf3f4165ed57f8))
* **parse:** remove_watermark output option with 2026-09-28 tier versions ([#27813](https://github.com/run-llama/llama-parse-csharp/issues/27813)) ([b7e6cae](https://github.com/run-llama/llama-parse-csharp/commit/b7e6caeaa2a42c2de7c0ed4bf38883de97d826dc))
* **parse:** ship the illegible-classification prompts as agentic_plus 2026-09-11 (latest) ([#26490](https://github.com/run-llama/llama-parse-csharp/issues/26490)) ([5e7dd7a](https://github.com/run-llama/llama-parse-csharp/commit/5e7dd7a4a4ad246fe49eb99903b65eaa2da3dabd))
* **sdk:** publish beta.attachments list and get ([184eb3c](https://github.com/run-llama/llama-parse-csharp/commit/184eb3c066b2cda3fdc46d2037f56a66de36035e))
* **split:** accept a parse config or parse_job_id like extract_v2 ([#26303](https://github.com/run-llama/llama-parse-csharp/issues/26303)) ([fc152c9](https://github.com/run-llama/llama-parse-csharp/commit/fc152c9b170d0a163c7bae55d00c5b96c8c3e720))
* **split:** target_pages page selection when splitting a parse job ([#26921](https://github.com/run-llama/llama-parse-csharp/issues/26921)) ([72cb9fe](https://github.com/run-llama/llama-parse-csharp/commit/72cb9fe2d5bca3667742401815aa272e9cb61ebc))


### Bug Fixes

* **chat:** report every index a chat turn could not query ([#26981](https://github.com/run-llama/llama-parse-csharp/issues/26981)) ([cfe7db5](https://github.com/run-llama/llama-parse-csharp/commit/cfe7db561c6c7fea88b28da48cf1fbcebb2ca646))
* **ci:** give resolver builds a real commit subject (LI-9592) ([974210c](https://github.com/run-llama/llama-parse-csharp/commit/974210cf7fe9b7a6b59c94d1aa812d39f86b3384))
* **extract:** refuse to delete a non-terminal job (LI-8700) ([#23793](https://github.com/run-llama/llama-parse-csharp/issues/23793)) ([f5b6707](https://github.com/run-llama/llama-parse-csharp/commit/f5b6707330a4c68e8429386651105abf716d29e6))
* **split:** process target_pages in the order written, matching Extract ([#28173](https://github.com/run-llama/llama-parse-csharp/issues/28173)) ([96a79e2](https://github.com/run-llama/llama-parse-csharp/commit/96a79e2b122f4295924ec014b75dc64412f8594b))


### Chores

* **sync:** resolve back-sync conflicts with production ([888c794](https://github.com/run-llama/llama-parse-csharp/commit/888c79483e57cd813b37c09d3439473d200455ab))


### Documentation

* **changelog:** record the classify v1 job removal in 1.7.0 ([c6ebdbf](https://github.com/run-llama/llama-parse-csharp/commit/c6ebdbf849908690c64c45ee7ef3d9386ed6dd4a))
* **changelog:** record the classify v1 job removal in 1.7.0 ([4bc1096](https://github.com/run-llama/llama-parse-csharp/commit/4bc1096921a0b094f45a9a76e387f23bfce4afbc))
* update Extract versions and pricing ([#28128](https://github.com/run-llama/llama-parse-csharp/issues/28128)) ([abf60f8](https://github.com/run-llama/llama-parse-csharp/commit/abf60f89bda422749b8969a37ed845eda228fd2b))

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
