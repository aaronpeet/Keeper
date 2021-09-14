<template>
  <div class="home flex-grow-1 container">
    <div class="row">
      <div class="col" v-for="k in keeps" :key="k.id">
        <KeepsCard :keep="k" />
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from '@vue/runtime-core'
import Pop from '../utils/Notifier'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
export default {
  setup() {
    onMounted(async() => {
      try {
        await keepsService.getAllKeeps()
      } catch (error) {
        Pop.toast('Something is had gone wrong', 'error')
      }
    })
    return {
      keeps: computed(() => AppState.keeps)
    }
  }
}
</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
  > img{
    height: 200px;
    width: 200px;
  }
}
</style>
