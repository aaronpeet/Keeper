<template>
  <!-- Modal -->
  <div class="modal fade"
       id="createVaultModal"
       tabindex="-1"
       role="dialog"
       aria-labelledby="modelTitleId"
       aria-hidden="true"
  >
    <div class="modal-dialog modal-lg " role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">
            Add a Vault!
          </h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <form @submit.prevent="createVault">
            <div class="form-group w-100">
              <label for="name"><b>Name</b></label>
              <input type="text"
                     name="name"
                     id="name"
                     v-model="state.newVault.name"
                     class="form-control"
                     placeholder="Name your keep..."
                     aria-describedby="nameHelpText"
                     required
              >
              <small id="nameHelpText" class="text-muted">Input Vault Name</small>
            </div>
            <div class="form-group w-100">
              <label for="description"><b>Description</b></label>
              <input type="text"
                     name="description"
                     id="description"
                     v-model="state.newVault.description"
                     class="form-control"
                     placeholder="Description..."
                     aria-describedby="nameHelpText"
                     maxlength="140"
                     required
              >
              <small id="nameHelpText" class="text-muted">Input Vault Description</small>
            </div>
            <div class="form-check">
              <input class="form-check-input" v-model="state.newVault.isPrivate" type="checkbox" value="" id="is Private">
              <label class="form-check-label" for="flexCheckDefault">
                Private?
              </label>
            </div>
            <small id="nameHelpText" class="text-muted">A private vault can only be seen by you.</small>
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
import { vaultsService } from '../services/VaultsService'
import $ from 'jquery'
export default {

  setup() {
    const state = reactive({
      newVault: {}
    })
    return {
      state,
      async createVault() {
        try {
          await vaultsService.createVault(state.newVault)
          state.newVault = {}
          $('#createVaultModal').modal('hide')
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
