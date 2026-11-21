# Changelog

## [1.11.0](https://github.com/run-llama/llama-parse-csharp/compare/v1.10.0...v1.11.0) (2026-11-20)


### Features

* **extract:** expose Max effort in the public API ([#30756](https://github.com/run-llama/llama-parse-csharp/issues/30756)) ([df59994](https://github.com/run-llama/llama-parse-csharp/commit/df59994d1a480319409bd5da431e0d0e0fe937ee))
* **extract:** send a saved configuration's completed jobs to review by policy ([#34124](https://github.com/run-llama/llama-parse-csharp/issues/34124)) ([a23dfb8](https://github.com/run-llama/llama-parse-csharp/commit/a23dfb89323a5e71e0fb6c93b7b9d19f9103a16e))
* **parse-eval:** keep ground truth in Evaluate-owned storage ([#33781](https://github.com/run-llama/llama-parse-csharp/issues/33781)) ([885be2b](https://github.com/run-llama/llama-parse-csharp/commit/885be2ba7d235848c25b0bb84178f1a41a329582))
* **parse-eval:** let Parse delete ground-truth jobs like any other job ([#35004](https://github.com/run-llama/llama-parse-csharp/issues/35004)) ([3cb593a](https://github.com/run-llama/llama-parse-csharp/commit/3cb593a46464b72e7d570bcd66630ef95283e325))
* **parse:** add document page count bounds ([#34227](https://github.com/run-llama/llama-parse-csharp/issues/34227)) ([56eecd0](https://github.com/run-llama/llama-parse-csharp/commit/56eecd0a090575f9654652b565b34ddffaf82f45))
* **parse:** Agentic and Cost Effective 2026-11-09 lead with OCRIA 1.5 ([#33718](https://github.com/run-llama/llama-parse-csharp/issues/33718)) ([4796f5e](https://github.com/run-llama/llama-parse-csharp/commit/4796f5e6194c4163796729f3baf1906c917c61b6))
* **parse:** optional `bbox` on form text grounding in the public API schema ([#35073](https://github.com/run-llama/llama-parse-csharp/issues/35073)) ([6ac8517](https://github.com/run-llama/llama-parse-csharp/commit/6ac85177d33ae1852962021cf940616d665f1bb3))
* **split:** advisory warnings for ambiguous category configs ([#34714](https://github.com/run-llama/llama-parse-csharp/issues/34714)) ([7514c52](https://github.com/run-llama/llama-parse-csharp/commit/7514c52c8c48730cc89a8cf4a27c4727af3b4589))
* **split:** category segment boundary in 1.3.0 ([#35081](https://github.com/run-llama/llama-parse-csharp/issues/35081)) ([acca181](https://github.com/run-llama/llama-parse-csharp/commit/acca181ed74d6e1423090198b5726190e0f7e5e9))
* **split:** report the job's Split version on v1 SplitJobResponse ([#30318](https://github.com/run-llama/llama-parse-csharp/issues/30318)) ([31dd5aa](https://github.com/run-llama/llama-parse-csharp/commit/31dd5aa8515aaaac461440b709dccc4cac93f13c))
* **webhooks:** keep a saved webhook's masked credentials by its id ([#32736](https://github.com/run-llama/llama-parse-csharp/issues/32736)) ([677cd96](https://github.com/run-llama/llama-parse-csharp/commit/677cd967cf6b8bcbd9613e32252e4c4c463fe97b))


### Bug Fixes

* **api:** reject a page_size below 1 on every list route's pagination query (PROD-10603) ([#30406](https://github.com/run-llama/llama-parse-csharp/issues/30406)) ([45de8f2](https://github.com/run-llama/llama-parse-csharp/commit/45de8f2152a9095f155c28f3c0ef78436db51f8c))
* keep legacy pipelines with empty embedding configs listable ([#31282](https://github.com/run-llama/llama-parse-csharp/issues/31282)) ([2786972](https://github.com/run-llama/llama-parse-csharp/commit/2786972ae6b359695a23b07388d86c76ac5c9282))
* **split:** reject category names that make segment labels ambiguous (PROD-10501) ([#29963](https://github.com/run-llama/llama-parse-csharp/issues/29963)) ([69e62a0](https://github.com/run-llama/llama-parse-csharp/commit/69e62a0163b58f5f4c504803025c5518c7a37a04))


### Documentation

* **extract:** describe Max effort pricing by the processing each document needs ([#33403](https://github.com/run-llama/llama-parse-csharp/issues/33403)) ([b535fe8](https://github.com/run-llama/llama-parse-csharp/commit/b535fe807474fdce89ca50ad17561be81b887346))
* **split:** PPTX segment pages count visible slides only (PROD-10504) ([#29972](https://github.com/run-llama/llama-parse-csharp/issues/29972)) ([a135cfb](https://github.com/run-llama/llama-parse-csharp/commit/a135cfb1f1230cced06d8a0c545a2409e7862ba3))

## [1.10.0](https://github.com/run-llama/llama-parse-csharp/compare/v1.9.0...v1.10.0) (2026-10-21)


### Features

* **classify:** add expand=usage to GET /api/v2/classify/{job_id} ([#29577](https://github.com/run-llama/llama-parse-csharp/issues/29577)) ([f98a24f](https://github.com/run-llama/llama-parse-csharp/commit/f98a24fa27d8205bf1f49cc7facf8585fbb0b3dd))


### Bug Fixes

* **parse:** apply watermark and wrapped-word rules to Lite fallbacks ([#30128](https://github.com/run-llama/llama-parse-csharp/issues/30128)) ([8edd798](https://github.com/run-llama/llama-parse-csharp/commit/8edd798f17910b5fd9975c573d90643cc23d87f2))
* **sdk:** one FormText model for the forms text node (PROD-10339) ([02562bf](https://github.com/run-llama/llama-parse-csharp/commit/02562bf3527e11c05ede7cad78b58c60ecf91636))
* **split:** refuse to delete a non-terminal job ([#29785](https://github.com/run-llama/llama-parse-csharp/issues/29785)) ([cf79740](https://github.com/run-llama/llama-parse-csharp/commit/cf7974095bc4ddfb5442ff93b7f7c52679fd72a3))

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
