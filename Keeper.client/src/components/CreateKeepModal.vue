<template>
  <!-- Modal -->
  <div class="modal fade"
       id="createKeepModal"
       tabindex="-1"
       role="dialog"
       aria-labelledby="modelTitleId"
       aria-hidden="true"
  >
    <div class="modal-dialog modal-lg " role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">
            Add a Keep!
          </h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <form @submit.prevent="createKeep">
            <div class="form-group w-100">
              <label for="name"><b>Name</b></label>
              <input type="text"
                     name="name"
                     id="name"
                     v-model="state.newKeep.name"
                     class="form-control"
                     placeholder="Name your keep..."
                     aria-describedby="nameHelpText"
                     required
              >
              <small id="nameHelpText" class="text-muted">Input Keep Name</small>
            </div>
            <div class="form-group w-100">
              <label for="description"><b>Description</b></label>
              <input type="text"
                     name="description"
                     id="description"
                     v-model="state.newKeep.description"
                     class="form-control"
                     placeholder="Description..."
                     aria-describedby="nameHelpText"
                     maxlength="140"
                     required
              >
              <small id="nameHelpText" class="text-muted">Input Keep Description</small>
            </div>
            <div class="form-group w-100">
              <label for="Img"><b>Image URL</b></label>
              <input type="text"
                     name="Img"
                     id="name"
                     v-model="state.newKeep.img"
                     class="form-control"
                     placeholder="Image URL..."
                     aria-describedby="nameHelpText"
                     required
              >
              <small id="nameHelpText" class="text-muted">Input Keep Image</small>
            </div>
            <div class="modal-footer p-0 pt-3">
              <button type="submit" class="btn btn-success">
                Submit
              </button>
              <button type="button" class="btn btn-danger" data-dismiss="modal">
                Close
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
import Pop from '../utils/Notifier'
import { keepsService } from '../services/KeepsService'
import $ from 'jquery'
export default {

  setup() {
    const state = reactive({
      newKeep: {}
    })
    return {
      state,
      async createKeep() {
        try {
          await keepsService.createKeep(state.newKeep)
          state.newKeep = {}
          $('#createKeepModal').modal('hide')
        } catch (error) {
          Pop.toast(error)
        }
      }
    }
  }
}
</script>

<style lang="scss" scoped>

</style>
