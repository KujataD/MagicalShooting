# 【1-03】フォルダの外の忘れ物を確認しよう【1章：パッケージ編】

1. クリア条件：自分のフォルダの外にある「持っていけないもの」に気づけばOK！

2. 前回、ミニゲームのファイルを1つのフォルダにまとめました。
   ただし、**Unity Packageに入らないもの**がいくつかあります。ここを知らずに提出すると、統合したときに「自分の環境では動いたのに、統合したら動かない」が起きます。

3. Unity Packageに入るもの／入らないものは、こう分かれます。

   | 種類 | 場所 | パッケージに入る？ |
   |---|---|---|
   | 画像・音・スクリプト・シーン・プレハブ | Assets の中 | ⭕ 入る（選んだものだけ） |
   | Package Manager で入れた機能 | Packages | ✕ 入らない |
   | タグ・レイヤー・入力設定・物理設定など | Project Settings | ✕ 入らない |
   | Build Settings のシーン一覧 | Project Settings | ✕ 入らない |

4. 【確認1】自分のフォルダの外にあるファイルを使っていないか

   前回作ったフォルダの外に、使っている素材が残っていないか確認しましょう。
   例えば「共通で使うフォントを Assets/Fonts に置いたまま」だと、フォルダごと書き出しても付いてきません。

   これは書き出しのときにUnityが自動で調べてくれます（次回1-04の「Include dependencies」）。ただし自動でも拾えないものがあるので、下の2つは自分で確認してください。

5. 【確認2】Package Manager で追加した機能

   TextMeshPro、Cinemachine、DOTweenなど、後から追加した機能は**パッケージに入りません**。
   使っている場合は、提出時にReadMe.mdへ書く必要があります（1-06でやります）。

   確認するには、`Window > Package Management > Package Manager` を開きます。

   ![Package Managerを開くメニュー](../package_images/1-03_packagemanager_menu.png)

   左側の「In Project」を選ぶと、このプロジェクトで使っている機能の一覧が表示されます。

   ![Package ManagerのIn Project表示](../package_images/1-03_package_manager.png)

   ※Unityに最初から入っているものはそのままでOKです。自分で追加した覚えのあるものだけメモしておいてください。

6. 【確認3】タグ・レイヤー・入力設定

   `Project Settings` の中身は、パッケージには**一切入りません**。特に次の3つはミニゲームでよく使うので要注意です。

   - **Tag（タグ）**：`Player` や `Enemy` など、自分で追加したタグ
   - **Layer（レイヤー）**：自分で追加したレイヤー、Layer Collision Matrix の設定
   - **Input（入力）**：Input Managerで追加した軸の名前、Input Systemの設定ファイル

   `Edit > Project Settings...` を開いて、左のリストから「Tags and Layers」を選びます。「Tags」の欄を開いて、自分で追加したものがあればメモしておきましょう。

   ![Tags and Layersの画面](../package_images/1-03_tags_layers.png)

   ※スクショのように「List is empty」と表示されていれば、自分で追加したタグは無いということです。この場合は「なし」と書けばOK。
   ※`Untagged` `MainCamera` `Player` などの最初からあるタグは、統合先にも最初からあるので大丈夫です。

7. 【対策】スクリプトでタグを使っている場合の注意

   例えばスクリプトにこう書いてあるとします。

   ```csharp
   if (other.gameObject.tag == "Item")
   ```

   このとき統合先に `Item` タグが無いと、実行時にエラーが出てゲームが止まります。
   **自分で追加したタグは必ず書き残してください**。迷とら運営が統合先に同じタグを追加します。

8. ここでメモした内容は、1-06で作るReadMe.mdにそのまま書きます。
   メモしておく項目はこの4つです。

   - 追加した機能（Package Managerで入れたもの）
   - 追加したタグ
   - 追加したレイヤー
   - 最初に開くシーンの名前

9. 自分のフォルダの外に何があるか把握できたら、今回は完成です！
   次回はいよいよ書き出します。
