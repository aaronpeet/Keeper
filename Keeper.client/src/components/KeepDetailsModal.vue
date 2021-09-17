<template>
  <!-- Modal -->
  <div
    class="modal fade"
    :id="'keepDetailsModal' + keep.id"
    tabindex="-1"
    role="dialog"
    aria-labelledby="modelTitleId"
    aria-hidden="true"
  >
    <div class="modal-dialog modal-lg" role="document">
      <div class="modal-content modal-height">
        <div class="modal-header">
          <h1 class="modal-title">
            {{ keep.name }}
          </h1>

          <button type="button" class="close" data-dismiss="modal" aria-label="Close" title="close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body modal-overflow">
          <div class="row p-3 my-3">
            <div class="col-md-6 col-12 mb-3">
              <img class="modalImg"
                   :src="keep.img"
                   :alt="keep.name"
              >
            </div>
            <div class="col-md-6 col-12 px-3">
              <div class="d-flex justify-content-between ml-3">
                <div>
                  <p>Keeps: {{ keep.keeps }}</p>
                </div>
                <div>
                  <p>Views: {{ keep.views }}</p>
                </div>
              </div>
              <div>
                <p><em>{{ keep.description }}</em></p>
              </div>
            </div>
            <div class="col">
              <div class="dropdown">
                <button class="btn btn-secondary dropdown-toggle"
                        type="button"
                        id="dropdownMenu2"
                        data-toggle="dropdown"
                        aria-haspopup="true"
                        aria-expanded="false"
                        title="Add to vault"
                >
                  Add to Vault
                </button>
                <div class="dropdown-menu" aria-labelledby="dropdownMenu2">
                  <VaultSelect v-for="v in vaults" :key="v.id" :vault="v" />
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-dismiss="modal" title="close">
            Close
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from '@vue/runtime-core'
import { AppState } from '../AppState'
export default {
  props: {
    keep: {
      type: Object,
      required: true
    }
  },
  setup() {
    const state = reactive({
      account: computed(() => AppState.account)
    })
    return {
      state,
      vaults: computed(() => AppState.myActiveVaults)
    }
  }
}
</script>

<style lang="scss" scoped>
.modalImg{
  max-width: 100%;
}
.modal-overflow{
  overflow: auto;
}
.modal-height{
    max-height: 95vh;
}
</style>
