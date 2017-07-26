; (function () {
    var list = [];
    var Item = (function () {
            var id = 1;
            return function (title, content) {
                this.title = title;
                this.content = content;
                this.id = id++;
            }
        })();
        
        var searchBar ={
            template:`
            <div class="row toolbar">
                <div class="col-md-8">
                    keyword：
                    <input type="text" v-model="keyword" />
                    <input type="button" @click="search()" value="search" class="btn btn-primary" />
                </div>
            </div>
            `,
            data:function(){
                return{
                    keyword:''
                }
            },
            methods:{
                search:function(){
                    this.$emit('onsearch',this.keyword);
                }
            }
        }

        var todoForm={
            template:`
            <div class="col-md-6">
                <input type="hidden" v-bind:value="todo.id" />
                <div class="form-inline">
                    <label for="title" class="control-label col-md-4">title:</label>
                    <input type="text" v-model="todo.title" class="form-control col-md-8">
                </div>
                <div class="form-inline">
                    <label for="content" class="control-label col-md-4">content</label>
                    <input type="text" v-model="todo.content" class="form-control col-md-8">
                </div>
                <div class="form-inline">
                    <input type="button" value="save" v-on:click="save()" class="btn btn-primary offset-md-10" />
                </div>
             </div>
            `,
            props:['initItem'],
            computed:{
                todo:function(){
                    return {id:this.initItem.id,title:this.initItem.title,content:this.initItem.content};
                }
                /*,
                canSave:function(){
                    return !this.initItem.title || !this.initItem.content;
                }*/
            },
            methods:{
                save:function(){
                    this.$emit("onsave",this.todo);
                }
            }
        }

        var todoItem={
            template:`
             <tr>
                    <td>{{todo.id}}</td>
                    <td>{{todo.title}}</td>
                    <td>{{todo.content}}</td>
                    <td>
                        <input type="button" value="edit" v-on:click='edit()' class="btn btn-info">
                        <input type="button" value="remove" @click="remove()" class="btn btn-danger" />
                    </td>
                </tr>
            `,
            props:['todo'],
            methods:{
                edit:function(){
                    console.log(this.todo);
                    this.$emit('onedit',this.todo.id);
                },
                remove:function(){
                    console.log(this.todo);
                    this.$emit('onremove',this.todo.id);
                }
            }
        }
        var todoList={
            template:`
             <div class="col-md-6">
            <table class="table table-bordered">
                <tr>
                    <th>Id</th>
                    <th>title</th>
                    <th>content</th>
                    <th>Operate</th>
                </tr>
                <todo-item v-for="item in items" :todo="item" :key="item.id" @onedit="edit($event)" @onremove="remove($event)">
                </todo-item>
                </table>
                </div>
            `,
            props:['items'],
            components:{
                'todo-item':todoItem
            },
            methods:{
                edit:function($e){
                    this.$emit('onedit',$e);
                },
                remove:function($e){
                    this.$emit('onremove',$e);
                }
            }
        }
        var todoContainer={
            template:`
            <div class='container'>
                <search-bar @onsearch='search($event)'></search-bar>
                <div class='row'>
                    <todo-list :items="items" @onremove='remove($event)' @onedit='edit($event)'></todo-list>
                    <todo-form :init-item='initItem' @onsave='save($event)'></todo-form>
                </div>
            </div>
            `,
            components:{
                'search-bar':searchBar,
                'todo-form':todoForm,
                'todo-list':todoList
            },
            data:function(){
                return{
                    items:[],
                    initItem:{
                        id:'',
                        title:'',
                        content:''
                    }
                }
            },
            methods:{
                _mock_save:function(item){
                    list=item;
                },
                findById:function(id){
                 return this.items.filter(g=>g.id===id)[0]||{}
                },
                search:function($e){
                     this.items=list.filter(g=>g.title.indexOf($e) !==-1);
                     return this.items;
                },
                save:function($e){
                    if(this.initItem.id){
                        var obj = findById($e.id);
                        obj.title=$e.title;
                        obj.content=$e.content;

                    }
                    else{
                        var title=$e.title;
                        var content =$e.content;
                        this.items.push(new Item(title,content));
                    }
                    this.initItem={
                        title:'',
                        content:''
                    }

                    this._mock_save(this.items);
                },
                edit:function($e){
                    this.initItem=this.findById($e);
                },
                remove:function($e){
                    this.items=this.items.filter(g=>g.id !==$e);
                    this._mock_save(this.items);
                }
            }
        }

        new Vue({
            el:'#app',
            components:{
                'todo-container':todoContainer
        }});

})();
