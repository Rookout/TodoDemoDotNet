$().ready(() => {
    Vue.component('todo-item', {
        props: ['todo'],
        data: function () {
            return {
                editing: false
            }
        },
        methods: {
            saveTodoEdit(e) {
                if (e.keyCode != 13) return true;
                this.editing = false;
                this.$emit('update-todo', this.todo);
            },
            onTodoToggle(e) {
                this.editing = false;
                this.$emit('update-todo', this.todo);
            }
        },
        template: `<li v-bind:class="{ completed: todo.completed, editing: editing }">
                <div class="view">
                  <input class="toggle" type="checkbox" @change="onTodoToggle" v-model="todo.Completed" data-selector="checkbox-todo-toggle">
                  <label class="todo-label" v-on:dblclick="editing=true">{{ todo.Title }}</label>
                  <button class="duplicate" v-on:click="$emit('duplicate-todo',todo)" data-selector="button-todo-duplicate"></button>
                  <button class="destroy" v-on:click="$emit('remove-todo',todo)" data-selector="button-todo-remove"></button>
                </div>
                <input class="edit" type="text" v-on:keypress="saveTodoEdit" v-model="todo.Title" data-selector="input-todo-edit">
              </li>`
    });

    var app = new Vue({
        el: "#app",
        data: {
            todos: [],
            newTodoTitle: '',
            filterMode: 'all',
            todosFilter: (todo) => true
        },
        computed: {
            filteredTodos() {
                return this.todos.filter(this.todosFilter);
            }
        },
        methods: {
            setFilter(filter) {
                this.filterMode = filter;
                switch (filter) {
                    case 'all':
                        this.todosFilter = (todo) => true;
                        break;
                    case 'active':
                        this.todosFilter = (todo) => !todo.Completed;
                        break;
                    case 'completed':
                        this.todosFilter = (todo) => todo.Completed;
                        break;
                }
            },
            toggleAll() {
                this.todos.forEach(todo => {
                    let toggledTodo = todo;
                    toggledTodo.Completed = !toggledTodo.Completed;
                    const action = $.ajax(`/api/todos/update`, {
                        contentType: 'application/json',
                        method: 'PUT',
                        data: JSON.stringify(toggledTodo),
                        dataType: 'json',
                    });
                });
                this.reloadTodos();
            },
            clearCompleted(e) {
                const action = $.ajax('/api/todos/clear_completed', {
                    method: 'DELETE'
                });
                this.reloadOnFinish(action);
            },
            updateTodo(todo) {
                const action = $.ajax(`/api/todos/update`, {
                    contentType: 'application/json',
                    method: 'PUT',
                    data: JSON.stringify(todo),
                    dataType: 'json',
                });
                this.reloadOnFinish(action);
            },
            duplicateTodo(todo) {
                const action = $.ajax(`/api/todos/dup/${todo.ID}`, {
                    method: 'POST'
                });
                this.reloadOnFinish(action);
            },
            removeTodo(todo) {
                const action = $.ajax(`/api/todos/delete/${todo.ID}`, {
                    method: 'DELETE',
                });
                this.reloadOnFinish(action);
            },
            removeAll() {
                const action = $.ajax('/todos/delete_all', {
                    method: 'DELETE'
                });
                this.reloadOnFinish(action);
            },
            reloadOnFinish(promise) {
                promise.done((data) => {
                    return this.reloadTodos();
                }).catch(console.log);
            },
            
            reloadTodos() {
                const vm = this;
                $.ajax('/api/todos', {
                    method: 'GET'
                }).done((todos) => {
                    vm.todos = todos.data;
                });
            },
            addTodo(text) {
                const action = $.ajax('/api/todos/add', {
                    contentType: 'application/json',
                    method: 'POST',
                    data: JSON.stringify({ "Title": text, "Completed": false }),
                    dataType: 'json'
                });

                this.reloadOnFinish(action);
            },
            onAddTodoPressed(e) {
                if (e.keyCode !== 13) return;
                const title = this.newTodoTitle;
                this.addTodo(title);
                this.newTodoTitle = '';
            }
        },
        mounted() {
            this.reloadTodos();
        },
    });
});